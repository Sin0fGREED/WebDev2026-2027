using Hollowmere.Data.Models;

using System.ComponentModel.DataAnnotations;

namespace Hollowmere.Server.DTOs;

public record CreatureDTO(int Id, Guid GuildId, string Name, string Region, string Description, bool IsDangerous, string? ImageUri);

public class CreatureCreateDTO
{
    [Required]
    public Guid GuildId { get; set; }

    [Required, MinLength(1), MaxLength(128)]
    public required string Name { get; set; }

    [Required, MinLength(1), MaxLength(128)]
    public required string Region { get; set; }

    [Required, MinLength(1), MaxLength(1024)]
    public required string Description { get; set; }

    [Required]
    public bool IsDangerous { get; set; }

    [MaxLength(256)]
    public string? ImageUri { get; set; }
}

public class CreatureEditDTO : CreatureCreateDTO
{
    [Required]
    public int Id { get; set; }
}

public static class CreatureConverter
{
    public static CreatureDTO ToDto(this Creature creature) => new(creature.Id, creature.GuildId, creature.Name, creature.Region, creature.Description, creature.IsDangerous, creature.ImageUri);

    public static Creature FromCreateDTO(this CreatureCreateDTO dto) => new()
    {
        Name = dto.Name,
        Region = dto.Region,
        Description = dto.Description,
        IsDangerous = dto.IsDangerous,
        ImageUri = dto.ImageUri
    };

    public static Creature FromEditDTO(this CreatureEditDTO dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        Region = dto.Region,
        Description = dto.Description,
        IsDangerous = dto.IsDangerous,
        ImageUri = dto.ImageUri
    };
}
