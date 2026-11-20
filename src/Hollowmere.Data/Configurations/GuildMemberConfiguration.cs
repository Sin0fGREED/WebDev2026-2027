using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class GuildMemberConfiguration : IEntityTypeConfiguration<GuildMember>
{
    public void Configure(EntityTypeBuilder<GuildMember> builder)
    {
        builder.HasKey(gm => new { gm.GuildId, gm.UserId });

        builder.Property(gm => gm.IsTrained)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne(gm => gm.Guild)
            .WithMany()
            .HasForeignKey(gm => gm.GuildId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(gm => gm.User)
            .WithMany()
            .HasForeignKey(gm => gm.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}