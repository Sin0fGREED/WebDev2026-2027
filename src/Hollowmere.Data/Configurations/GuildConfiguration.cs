using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class GuildConfiguration : IEntityTypeConfiguration<Guild>
{
    public void Configure(EntityTypeBuilder<Guild> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasOne(g => g.GuildOwner)
            .WithMany()
            .HasForeignKey(g => g.GuildOwnerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
