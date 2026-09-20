using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace Hollowmere.Data.Tests.Configuration;

public class CreatureConfigurationTests
{
    [Fact]
    public async Task Name_And_Region_Must_Be_Unique()
    {
        // Arrange
        var (context, connection) = DbFactory.Create();

        await using var _ = context;
        await using var __ = connection;

        var first = new Creature { Name = "Goblin", Region = "Forest", Description = "First" };
        var second = new Creature { Name = "Goblin", Region = "Forest", Description = "Second" };

        // Act
        context.Creatures.AddRange(first, second);
        var exception = await Record.ExceptionAsync(async ()
            => await context.SaveChangesAsync(TestContext.Current.CancellationToken));

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<DbUpdateException>(exception);
    }
}
