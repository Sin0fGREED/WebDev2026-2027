namespace Hollowmere.Data.Models;

public class GuildMember
{
    public Guid GuildId { get; set; }
    public Guid UserId { get; set; }

    public bool IsTrained { get; set; }

    public Guild Guild { get; set; } = null!;
    public User User { get; set; } = null!;
}
