using Bogus;

using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace Hollowmere.Data.Configurations;

public class CreatureConfiguration : IEntityTypeConfiguration<Creature>
{
    public void Configure(EntityTypeBuilder<Creature> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(c => c.Guild)
            .WithMany()
            .HasForeignKey(c => c.GuildId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(c => c.Region)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(1024);

        builder.Property(c => c.ImageUri)
            .HasMaxLength(512);

        builder.Property(c => c.IsDangerous)
            .IsRequired()
            .HasDefaultValue(false);

        // To search for unique creatures by guildId, name and region
        builder.HasIndex(c => new { c.GuildId, c.Name, c.Region })
            .IsUnique();

        // To look up creatures by region
        builder.HasIndex(c => c.Region);
    }

    public static async Task SeedData(IServiceProvider modelBuilder)
    {
        // todo Add GuildId to the seed data for creatures. This will require creating a guild first and then using its Id when creating creatures.

        var context = modelBuilder.GetRequiredService<AppDbContext>();
        using var connection = context.Database.GetDbConnection();

        if (!context.Creatures.Any())
        {
            var entities = new List<Creature>
            {
                new() { Id = 1, Name = "Goblin", Region = "Forest", Description = "Small, green humanoid creatures that are often mischievous and sometimes dangerous.", IsDangerous = true },
                new() { Id = 2, Name = "Dragon", Region = "Mountains", Description = "Large, fire-breathing reptiles that are often depicted as powerful and fearsome.", IsDangerous = true },
                new() { Id = 3, Name = "Unicorn", Region = "Meadows", Description = "Mythical horse-like creatures with a single horn on their forehead, often associated with purity and grace.", IsDangerous = false },
                new() { Id = 4, Name = "Mermaid", Region = "Ocean", Description = "Half-human, half-fish creatures that are often depicted as beautiful and enchanting.", IsDangerous = false },
                new() { Id = 5, Name = "Troll", Region = "Caves", Description = "Large, brutish creatures that are often depicted as dim-witted and aggressive.", IsDangerous = true }
            };

            await using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                await context.Set<Creature>().AddRangeAsync(entities);
                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    // todo add guildId to the GetCreatures method and use it when creating the Faker<Creature> instances. This will require creating a guild first and then using its Id when creating creatures.
    public static Creature[] GetCreatures(int count, int seed) => [.. new Faker<Creature>().UseSeed(seed)
        .RuleFor(p => p.Id, f => f.IndexFaker + 1)
        .RuleFor(p => p.Region, f => f.Lorem.Word())
        .RuleFor(p => p.Description, f => f.Lorem.Sentence())

        .Generate(count)];
}
