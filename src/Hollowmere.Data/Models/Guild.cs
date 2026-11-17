namespace Hollowmere.Data.Models;

public class Guild
{
    public Guid Id { get; set; }
    public Guid GuildOwnerId { get; set; }

    public required string Name { get; set; }

    public User GuildOwner { get; set; } = null!;
}
