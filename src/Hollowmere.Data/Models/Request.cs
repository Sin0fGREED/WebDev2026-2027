namespace Hollowmere.Data.Models;

public class Request
{
    public Guid UserId { get; set; }
    public int QuestId { get; set; }

    public bool IsConfirmed { get; set; }

    public User User { get; set; } = null!;
    public Quest Quest { get; set; } = null!;
}
