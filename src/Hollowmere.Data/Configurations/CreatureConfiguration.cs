using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class CreatureConfiguration : IEntityTypeConfiguration<Creature>
{
    public void Configure(EntityTypeBuilder<Creature> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(c => c.Region)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(1024);

        builder.Property(c => c.ImageUri)
            .HasMaxLength(512);

        builder.Property(c => c.IsDangerous)
            .IsRequired()
            .HasDefaultValue(false);

        // To search for unique creatures by name and region
        builder.HasIndex(c => new { c.Name, c.Region })
            .IsUnique();

        // To look up creatures by region
        builder.HasIndex(c => c.Region);
    }
}
