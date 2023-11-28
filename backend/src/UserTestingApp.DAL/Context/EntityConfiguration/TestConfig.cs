using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserTestingApp.DAL.Entities;

namespace UserTestingApp.DAL.Context.EntityConfiguration;

internal class TestConfig : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(40);
    }
}
