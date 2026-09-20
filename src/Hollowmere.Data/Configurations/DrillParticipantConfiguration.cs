using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class DrillParticipantConfiguration : IEntityTypeConfiguration<DrillParticipant>
{
    public void Configure(EntityTypeBuilder<DrillParticipant> builder)
    {
        // Composite PK, can only participate once per drill
        builder.HasKey(dp => new { dp.DrillId, dp.UserId });

        builder.Property(dp => dp.HasParticipated)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne(dp => dp.Drill)
            .WithMany()
            .HasForeignKey(dp => dp.DrillId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(dp => dp.User)
            .WithMany()
            .HasForeignKey(dp => dp.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // To look up if userId HasParticipated
        builder.HasIndex(dp => new { dp.UserId, dp.HasParticipated });
    }
}
