using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.HasKey(r => new { r.QuestId, r.UserId });

        builder.Property(r => r.IsConfirmed)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(r => r.Quest)
            .WithMany()
            .HasForeignKey(r => r.QuestId)
            .OnDelete(DeleteBehavior.NoAction);

        // To look up all requests made by an user
        builder.HasIndex(r => r.UserId);
    }
}
