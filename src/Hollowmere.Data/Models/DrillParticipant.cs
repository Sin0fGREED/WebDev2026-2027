namespace Hollowmere.Data.Models;

public class DrillParticipant
{
    public int DrillId { get; set; }
    public Guid UserId { get; set; }

    public bool HasParticipated { get; set; }

    public Drill Drill { get; set; } = null!;
    public User User { get; set; } = null!;
}
