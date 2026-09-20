namespace Hollowmere.Data.Models;

public class Loan
{
    public int Id { get; set; }

    public int ItemId { get; set; }
    public Guid UserId { get; set; }

    public DateTimeOffset LoanDate { get; set; }
    public DateTimeOffset? ReturnDate { get; set; }

    public string? ReturnCondition { get; set; }

    public Item Item { get; set; } = null!;
    public User User { get; set; } = null!;
}
