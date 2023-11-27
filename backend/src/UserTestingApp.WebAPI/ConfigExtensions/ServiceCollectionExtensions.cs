using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using UserTestingApp.BLL.Interfaces;
using UserTestingApp.BLL.Options;
using UserTestingApp.BLL.Services;
using UserTestingApp.DAL.Context;
using UserTestingApp.DAL.Interfaces;
using UserTestingApp.DAL.Services;

namespace UserTestingApp.WebAPI.ConfigExtensions;

public static class ServiceCollectionExtensions
{
    public static void AddUserTestingAppContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("UserTestingAppContext");

        services.AddDbContext<UserTestingAppContext>(options =>
            options.UseSqlServer(
                connectionString, 
                opt => opt.MigrationsAssembly(typeof(UserTestingAppContext).Assembly.GetName().Name))
            );
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(EfRepository<>));

        services.AddScoped<ITestService, TestService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IUserIdStorageService, UserIdStorageService>();
        services.AddScoped<IUserIdGetter>(provider => provider.GetService<IUserIdStorageService>()!);
    }

    public static void AddJwtTokenAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<JwtOptions>(
            new JwtOptions
            {
                Issuer = configuration["Jwt:Issuer"] ?? throw new ArgumentNullException(),
                Audience = configuration["Jwt:Audience"] ?? throw new ArgumentNullException(),
                SecretKey = configuration["Jwt:SecretKey"] ?? throw new ArgumentNullException(),
                Lifetime = 30,
                SecurityAlgorithm = SecurityAlgorithms.HmacSha256
            });

        var signingKey = JwtOptions.GetSymmetricSecurityKey(configuration["Jwt:SecretKey"]!);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = configuration["Jwt:Issuer"],

            ValidateAudience = true,
            ValidAudience = configuration["Jwt:Audience"] ,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,

            ValidateLifetime = true
        };

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = tokenValidationParameters;
        });
    }

    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo {
                Title = "JWTToken_Auth_API", Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
                Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });
    }
}
