using Microsoft.EntityFrameworkCore;
using UserTestingApp.DAL.Context.EntityConfiguration;

namespace UserTestingApp.DAL.Context.ModelBuilderExtensions;

internal static class ConfigExtensions
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestConfig).Assembly);
    }
}
