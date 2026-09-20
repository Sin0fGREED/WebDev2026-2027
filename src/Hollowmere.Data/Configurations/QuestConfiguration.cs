using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class QuestConfiguration : IEntityTypeConfiguration<Quest>
{
    public void Configure(EntityTypeBuilder<Quest> builder)
    {
        builder.HasKey(q => q.Id);
        builder.Property(q => q.Id)
            .ValueGeneratedOnAdd();

        builder.Property(q => q.Village)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(q => q.Description)
            .IsRequired()
            .HasMaxLength(1024);

        builder.HasOne(q => q.Leader)
            .WithMany()
            .HasForeignKey(q => q.LeaderId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(q => q.Creature)
            .WithMany()
            .HasForeignKey(q => q.CreatureId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(q => q.DepartureDay)
            .IsRequired();

        builder.Property(q => q.DurationDays)
            .IsRequired();

        builder.Property(q => q.MaxPartySize)
            .IsRequired();

        builder.Property(q => q.IsCancelled)
            .IsRequired()
            .HasDefaultValue(false);

        // To look up all quests by a specific leader
        builder.HasIndex(q => q.LeaderId);

        // to look up all quests by village
        builder.HasIndex(q => q.Village);

        // To look up all quests set to depart on a specified day
        builder.HasIndex(q => q.DepartureDay);

        // To look up all quests with a specific Creature
        builder.HasIndex(q => q.CreatureId);
    }
}
