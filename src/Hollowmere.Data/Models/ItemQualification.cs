namespace Hollowmere.Data.Models;

public class ItemQualification
{
    public Guid UserId { get; set; }
    public int ItemKindId { get; set; }

    public User User { get; set; } = null!;
    public ItemKind ItemKind { get; set; } = null!;
}
