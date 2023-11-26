using Microsoft.EntityFrameworkCore;
using UserTestingApp.BLL.Interfaces;
using UserTestingApp.BLL.Services;
using UserTestingApp.DAL.Context;
using UserTestingApp.DAL.Interfaces;
using UserTestingApp.DAL.Services;

namespace UserTestingApp.WebAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddUserTestingAppContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("UserTestingAppContext");

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
    }
}
