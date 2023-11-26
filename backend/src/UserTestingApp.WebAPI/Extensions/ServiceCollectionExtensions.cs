using Microsoft.EntityFrameworkCore;
using UserTestingApp.DAL.Context;

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
}
