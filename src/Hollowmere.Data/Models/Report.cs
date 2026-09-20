namespace Hollowmere.Data.Models;

public class Report
{
    public int Id { get; set; }

    public Guid AuthorId { get; set; }
    public int QuestId { get; set; }

    public required string Region { get; set; }
    public required string Notes { get; set; }

    public DateOnly DepartureDay { get; set; }

    public ReportStatus Status { get; set; } = ReportStatus.Draft;

    public User Author { get; set; } = null!;
    public Quest Quest { get; set; } = null!;
}
