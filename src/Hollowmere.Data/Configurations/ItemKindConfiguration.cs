using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class ItemKindConfiguration : IEntityTypeConfiguration<ItemKind>
{
    public void Configure(EntityTypeBuilder<ItemKind> builder)
    {
        builder.HasKey(ik => ik.Id);
        builder.Property(ik => ik.Id)
            .ValueGeneratedOnAdd();

        builder.Property(ik => ik.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.HasIndex(ik => ik.Name)
            .IsUnique();
    }
}
