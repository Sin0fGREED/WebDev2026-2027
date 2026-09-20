namespace Hollowmere.Data.Models;

public class Item
{
    public int Id { get; set; }

    public int ItemKindId { get; set; }

    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Condition { get; set; }

    public bool IsRetired { get; set; }
    public bool IsDangerous { get; set; }

    public ItemKind ItemKind { get; set; } = null!;
}
