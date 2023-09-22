using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.DAL.UnitOfWork;
using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.HelperClasses;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.projectInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
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
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UmsaSofttek", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

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

//Serilog configuration and file path

Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log/TechOilLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();

//Setting serilog as the logger, ILogger uses serilog settings
builder.Host.UseSerilog();

#region Scoped Services

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IWorkService, WorkService>();
builder.Services.AddScoped<IServiceService, ServiceService>();


#endregion

#region JWT Configuration

// Gets JWT parameters from appsettings.json, mapping the properties from JSON to the object.
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

// Adds JWT authorization as a service, defining Bearer as the authentication scheme, and setting parameters for JWT token validation.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
    });

// Adds JWT configuration to make it available.
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

#endregion

#region JWT Authorization

// Adds authorization based on policies and roles in our JWT.
builder.Services.AddAuthorization(option =>
{
    //Creates policies for both the Administrador and Consultor roles,based on their PKs
    option.AddPolicy("Administrador", policy => policy.RequireClaim(ClaimTypes.Role, "Administrador"));
    option.AddPolicy("Consultor", policy => policy.RequireClaim(ClaimTypes.Role, "Consultor"));

    //Creates a policy that authorizes a token if their Role claim is either 1 or 2 ( Administrador or Consultor )
    option.AddPolicy("AdministradorOrConsultor", policy => policy.RequireClaim(ClaimTypes.Role,"Administrador","Consultor"));

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