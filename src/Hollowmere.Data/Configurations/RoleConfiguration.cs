using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd();

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(r => r.Description)
            .IsRequired()
            .HasMaxLength(1024);

        builder.HasIndex(r => r.Name)
            .IsUnique();
    }
}
