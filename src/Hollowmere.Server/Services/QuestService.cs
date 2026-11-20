using Hollowmere.Data.Models;
using Hollowmere.Data.Repositories;
using Hollowmere.Server.DTOs;

using Microsoft.EntityFrameworkCore;

namespace Hollowmere.Server.Services;

public class QuestService(CreaturesRepository repository)
{
    public DbResponse<IEnumerable<QuestDTO>> GetAll()
    {
        var quest = repository.GetAll().Select(c => c.ToDto());

        return DbResponse<IEnumerable<QuestDTO>>.Success(quest);
    }

    public DbResponse<QuestDTO?> GetById(int id)
    {
        if (repository.GetById(id) is not Quest model)
            return DbResponse<QuestDTO?>.NotFound();

        return DbResponse<QuestDTO?>.Success(model.ToDto());
    }

    public async Task<DbResponse<QuestDTO>> Create(QuestCreateDTO quest)
    {
        if (repository.Exists(quest.LeaderId, quest.CreatureId, quest.GuildId, quest.Village, quest.Description))
        return DbResponse<QuestDTO>.Exists();

        try
        {
            var result = repository.Create(quest.FromCreateDTO());
            await repository.SaveChangesAsync();

            return DbResponse<QuestDTO>.Success(result.ToDto());
        }
        catch (DbUpdateConcurrencyException)
        {
            return DbResponse<QuestDTO>.Concurrency();
        }
        catch (Exception)
        {
            return DbResponse<QuestDTO>.Error();
        
        }
    }

    public async Task<DbResponse<QuestDTO>> Update(QuestEditDTO quest)
    {
        if (repository.Update(quest.LeaderId, quest.CreatureId, quest.GuildId, quest.Village, quest.Description))
        return DbResponse<QuestDTO.Exists();

        try
        {
            var result = repository.Update(quest.FromEditDTO());
            await repository.SaveChangesAsync();

            return DbResponse<QuestDTO>.Success(result.ToDto());
        }

        catch (DbUpdateConcurrencyException)
        {
            return DbResponse<QuestDTO>.Concurrency();
        }
        catch (Exception)
        {
            return DbResponse<QuestDTO>.Error();
        
        }
    }

    public async Task<DbResponse<bool>> Delete(int id)
    {
        try
        {
            var result = repository.Delete(id);
            await repository.SaveChangesAsync();

            return DbResponse<bool>.Success(result);
        }
        catch (ArgumentException)
        {
            return DbResponse<bool>.NotFound();
        }
        catch (DbUpdateConcurrencyException)
        {
            return DbResponse<bool>.Concurrency();
        }
        catch (Exception)
        {
            return DbResponse<bool>.Error();
        }
    }
}
