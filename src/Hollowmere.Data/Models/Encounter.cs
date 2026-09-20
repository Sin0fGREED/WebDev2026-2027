namespace Hollowmere.Data.Models;

public class Encounter
{
    public int Id { get; set; }

    public int ReportId { get; set; }
    public int CreatureId { get; set; }

    public required string Result { get; set; }

    public Report Report { get; set; } = null!;
    public Creature Creature { get; set; } = null!;
}
