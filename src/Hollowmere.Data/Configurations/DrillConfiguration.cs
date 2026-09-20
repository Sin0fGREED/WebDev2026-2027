using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class DrillConfiguration : IEntityTypeConfiguration<Drill>
{
    public void Configure(EntityTypeBuilder<Drill> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder.Property(d => d.Title)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(d => d.Description)
            .IsRequired()
            .HasMaxLength(1024);

        builder.Property(d => d.Date)
            .IsRequired();

        builder.Property(d => d.IsCancelled)
            .IsRequired()
            .HasDefaultValue(false);

        // To look for drills with a specific ItemKindId
        builder.HasIndex(d => d.ItemKindId);

        // To look up Drills by InstructorId
        builder.HasIndex(d => d.InstructorId);

        // To look up Drills on a specific Date (or range)
        builder.HasIndex(d => d.Date);

        builder.HasOne(d => d.Instructor)
            .WithMany()
            .HasForeignKey(d => d.InstructorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.ItemKind)
            .WithMany()
            .HasForeignKey(d => d.ItemKindId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}