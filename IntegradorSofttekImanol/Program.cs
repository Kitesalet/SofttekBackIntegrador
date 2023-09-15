using AutoMapper;
using IntegradorSofttekImanol.DAL;
using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.HelperClasses;
using IntegradorSofttekImanol.Models.Interfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Configuramos el swagger para poder agregar un campo de authorize token
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autorizacion JWT",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            }, new string[]{}
        }
    });


});

builder.Services.AddAutoMapper(typeof(MapperHelper));
builder.Services.AddDbContext<AppDbContext>(e => e.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();


//Se obtienen los parametros de Jwt en el appsettings.json,
//luego el ultimo .Get mappea las propiedades del json al objeto.

var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

//Se agrega la autorizacion con el JWT como service definiendo al bearer como scheme de auth
//Luego, los parametros para validar el token Jwt

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                    });


//Se agrega la config para que Jwt se encuentre disponible

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

//Se agrega la autorizacion en base a roles de la aplicacion como service
builder.Services.AddAuthorization(option =>
{
    //Cuando utilizemos un authorice de tipo admin, tiene que tener id 1
    option.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "1"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
