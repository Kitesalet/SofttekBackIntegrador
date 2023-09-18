using IntegradorSofttekImanol.DAL;
using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.HelperClasses;
using IntegradorSofttekImanol.Models.Interfaces;
using IntegradorSofttekImanol.Models.Interfaces.projectInterfaces;
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

// Configure Swagger to add an authorize token field
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization",
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

#region Scoped Services

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IProyectoService, ProyectoService>();
builder.Services.AddScoped<ITrabajoService, TrabajoService>();
builder.Services.AddScoped<IServicioService, ServicioService>();


#endregion

#region JWT Configuration

// Gets JWT parameters from appsettings.json, mapping the properties from JSON to the object.
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

// Adds JWT authorization as a service, defining Bearer as the authentication scheme, and setting parameters for JWT token validation.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
    });

// Adds JWT configuration to make it available.
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

#endregion

#region JWT Authorization

// Adds authorization based on application roles as service.
builder.Services.AddAuthorization(option =>
{

    option.AddPolicy("Administrador", policy => policy.RequireClaim(ClaimTypes.Role, "1"));
    option.AddPolicy("Consultor", policy => policy.RequireClaim(ClaimTypes.Role, "2"));

});

#endregion


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