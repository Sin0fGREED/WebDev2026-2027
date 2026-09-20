using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class EncounterConfiguration : IEntityTypeConfiguration<Encounter>
{
    public void Configure(EntityTypeBuilder<Encounter> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Result)
            .IsRequired()
            .HasMaxLength(1024);

        builder.HasOne(e => e.Report)
            .WithMany()
            .HasForeignKey(e => e.ReportId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Creature)
            .WithMany()
            .HasForeignKey(e => e.CreatureId)
            .OnDelete(DeleteBehavior.NoAction);

        // To look up all encounters for a specific Report
        builder.HasIndex(e => e.ReportId);
    }
}
