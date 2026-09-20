namespace Hollowmere.Data.Models;

public class User
{
    public Guid Id { get; set; }

    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public bool IsActive { get; set; } = true;

    public required string DisplayName { get; set; }

    public bool IsTrained { get; set; }
}
