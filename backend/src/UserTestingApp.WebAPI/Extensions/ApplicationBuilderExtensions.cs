using Microsoft.EntityFrameworkCore;
using UserTestingApp.DAL.Context;

namespace UserTestingApp.WebAPI.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void InitializeDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
        using var dbContext = scope?.ServiceProvider.GetRequiredService<UserTestingAppContext>();
        dbContext?.Database.Migrate();
    }
}
