using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
}
