namespace Hollowmere.Data.Models;

public class UserRole
{
    public Guid UserId { get; set; }
    public int RoleId { get; set; }
    public Guid GuildId { get; set; }

    public User User { get; set; } = null!;
    public Role Role { get; set; } = null!;
    public Guild Guild { get; set; } = null!;
}
