using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserTestingApp.DAL.Entities;

namespace UserTestingApp.DAL.Context.EntityConfiguration;

internal class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Username)
            .HasMaxLength(50);

        builder.HasIndex(u => u.Username)
            .IsUnique();
    }
}
