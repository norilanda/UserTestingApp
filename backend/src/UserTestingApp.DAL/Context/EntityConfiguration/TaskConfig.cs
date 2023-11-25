using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserTestingApp.DAL.Context.EntityConfiguration;

internal class TaskConfig : IEntityTypeConfiguration<Entities.Task>
{
    public void Configure(EntityTypeBuilder<Entities.Task> builder)
    {
        builder.Property(t => t.Question)
            .HasMaxLength(100);

        builder.Property(t => t.Answer)
            .HasMaxLength(100);
    }
}
