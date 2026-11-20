using Hollowmere.Data.Models;

using System.ComponentModel.DataAnnotations;

namespace Hollowmere.Server.DTOs;

public record QuestDTO(int Id, Guid LeaderId, int CreatureId, Guid GuildId, string Village, string Description, DateOnly DepartureDay, int DurationDays, int MaxPartySize, bool IsCancelled);

public class QuestCreateDTO
{
    [Required]
    public Guid LeaderId {get; set;}

    [Required]
    public int? CreatureId { get; set; }

    [Required]
    public Guid GuildId { get; set; }

    [Required, MinLength(1), MaxLength(128)]
    public required string Village { get; set; }

    [Required, MinLength(1), MaxLength(1024)]
    public required string Description { get; set; }

    [Required]
    public DateOnly DepartureDay { get; set; }

    [Required]
    public int DurationDays { get; set; }

// Questionable party size minimum should be 2 and i recon the party's can't be too big or it's going to be a raid so i was thinking of putting max range to 5,6,8 or 10
    [Required, Range(2,6)]
    public int MaxPartySize { get; set; }

    [Required]
    public bool IsCancelled { get; set; }

}

public class QuestEditDTO : QuestCreateDTO
{
    [Required]
    public int Id {get; set;}
}

public static class QuestConverter
{
    public static QuestDTO ToDto(this Quest quest) => new(quest.Id, quest.LeaderId, quest.CreatureId, quest.GuildId, quest.Village, quest.Description, quest.DepartureDay, quest.DurationDays, quest.MaxPartySize, quest.IsCancelled);
    public static Quest FromCreateDTO(this QuestCreateDTO dto) => new()
    {
        Village = dto.Village,
        Leader = dto.LeaderId,
        Creature = dto.CreatureId,
        Guild = dto.GuildId,
        Description = dto.Description,
        DepartureDay = dto.DepartureDay,
        DurationDays = dto.DurationDays,
        MaxPartySize = dto.MaxPartySize,
        IsCancelled = dto.IsCancelled
    };

    public static Quest FromEditDTO(this QuestEditDTO dto) => new()
    {
        Id = dto.Id,
        Village = dto.Village,
        Leader = dto.LeaderId,
        Creature = dto.CreatureId,
        Guild = dto.GuildId,
        Description = dto.Description,
        DepartureDay = dto.DepartureDay,
        DurationDays = dto.DurationDays,
        MaxPartySize = dto.MaxPartySize,
        IsCancelled = dto.IsCancelled
    };
}
