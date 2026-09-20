using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class ItemQualificationConfiguration : IEntityTypeConfiguration<ItemQualification>
{
    public void Configure(EntityTypeBuilder<ItemQualification> builder)
    {
        builder.HasKey(iq => new { iq.UserId, iq.ItemKindId });

        builder.HasOne(iq => iq.ItemKind)
            .WithMany()
            .HasForeignKey(iq => iq.ItemKindId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(iq => iq.User)
            .WithMany()
            .HasForeignKey(iq => iq.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // to look up which users are trusted with an item kind
        builder.HasIndex(iq => iq.ItemKindId);
    }
}