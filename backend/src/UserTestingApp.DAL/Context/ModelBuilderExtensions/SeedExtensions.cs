using Microsoft.EntityFrameworkCore;
using UserTestingApp.DAL.Entities;
using UserTestingApp.DAL.Helpers;

namespace UserTestingApp.DAL.Context.ModelBuilderExtensions;

internal static class SeedExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Test>()
            .HasData(DataGeneratorHelper.GenerateTests());

        modelBuilder.Entity<User>()
            .HasData(DataGeneratorHelper.GenerateUsers());

        modelBuilder.Entity<Entities.Task>()
            .HasData(DataGeneratorHelper.GenerateTasks());

        modelBuilder.Entity<AssignedTest>()
            .HasData(DataGeneratorHelper.GenerateAssignedTests());
    }
}
