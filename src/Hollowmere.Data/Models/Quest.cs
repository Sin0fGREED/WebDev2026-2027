namespace Hollowmere.Data.Models;

public class Quest
{
    public int Id { get; set; }

    public Guid LeaderId { get; set; }
    public int? CreatureId { get; set; }

    public required string Village { get; set; }
    public required string Description { get; set; }

    public DateOnly DepartureDay { get; set; }

    public int DurationDays { get; set; }
    public int MaxPartySize { get; set; }

    public bool IsCancelled { get; set; }

    public User Leader { get; set; } = null!;
    public Creature? Creature { get; set; }
}
