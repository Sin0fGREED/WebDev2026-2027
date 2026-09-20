using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id)
            .ValueGeneratedOnAdd();

        builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(i => i.Description)
            .IsRequired()
            .HasMaxLength(1024);

        builder.Property(i => i.Condition)
            .IsRequired()
            .HasMaxLength(1024);

        builder.Property(i => i.IsRetired)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(i => i.IsDangerous)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne(i => i.ItemKind)
            .WithMany()
            .HasForeignKey(i => i.ItemKindId)
            .OnDelete(DeleteBehavior.NoAction);

        // To look up items by ItemKindId
        builder.HasIndex(i => i.ItemKindId);

        // To search by name
        builder.HasIndex(i => i.Name);
    }
}
