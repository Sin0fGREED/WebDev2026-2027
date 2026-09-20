using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hollowmere.Data.Configurations;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id)
            .ValueGeneratedOnAdd();

        builder.Property(l => l.LoanDate)
            .IsRequired();

        builder.Property(l => l.ReturnDate)
            .IsRequired(false);

        builder.Property(l => l.ReturnCondition)
            .IsRequired(false)
            .HasMaxLength(1024);

        builder.HasOne(l => l.Item)
            .WithMany()
            .HasForeignKey(l => l.ItemId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(l => l.User)
            .WithMany()
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // To look up a user's loans, filtered by return date
        builder.HasIndex(l => new { l.UserId, l.ReturnDate });

        // To look up whether an item has been returned
        builder.HasIndex(l => new { l.ItemId, l.ReturnDate });

        // To look up what has been returned at a set time
        builder.HasIndex(l => l.ReturnDate);
    }
}
