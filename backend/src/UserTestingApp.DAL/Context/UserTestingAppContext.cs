using Microsoft.EntityFrameworkCore;
using UserTestingApp.DAL.Context.ModelBuilderExtensions;
using UserTestingApp.DAL.Entities;

namespace UserTestingApp.DAL.Context;

public class UserTestingAppContext : DbContext
{
    public DbSet<Test> Tests { get; set; }
    public DbSet<Entities.Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AssignedTest> AssignedTests { get; set; }

    public UserTestingAppContext(DbContextOptions<UserTestingAppContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Configure();
        modelBuilder.Seed();
    }
}
