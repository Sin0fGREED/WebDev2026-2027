using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd();

        builder.Property(r => r.Region)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(r => r.Notes)
            .IsRequired()
            .HasMaxLength(1024);

        builder.Property(r => r.DepartureDay)
            .IsRequired();

        builder.Property(r => r.Status)
            .IsRequired()
            .HasDefaultValue(ReportStatus.Draft);

        builder.HasOne(r => r.Quest)
            .WithMany()
            .HasForeignKey(r => r.QuestId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(r => r.Author)
            .WithMany()
            .HasForeignKey(r => r.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(r => r.QuestId);
        builder.HasIndex(r => r.Region);
        builder.HasIndex(r => new { r.AuthorId, r.Status });
    }
}
