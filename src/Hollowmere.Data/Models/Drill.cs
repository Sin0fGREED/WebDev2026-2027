namespace Hollowmere.Data.Models;

public class Drill
{
    public int Id { get; set; }

    public Guid InstructorId { get; set; }
    public int ItemKindId { get; set; }

    public required string Title { get; set; }
    public required string Description { get; set; }

    public bool IsCancelled { get; set; }
    public DateTimeOffset Date { get; set; }

    public User Instructor { get; set; } = null!;
    public ItemKind ItemKind { get; set; } = null!;
}
