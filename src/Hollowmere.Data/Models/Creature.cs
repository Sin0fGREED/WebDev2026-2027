namespace Hollowmere.Data.Models;

public class Creature
{
    public int Id { get; set; }

    public Guid GuildId { get; set; }

    public required string Name { get; set; }
    public required string Region { get; set; }
    public required string Description { get; set; }
    public bool IsDangerous { get; set; }
    public string? ImageUri { get; set; }

    public Guild Guild { get; set; } = null!;
}
