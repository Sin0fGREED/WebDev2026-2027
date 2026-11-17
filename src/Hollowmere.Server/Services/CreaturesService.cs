using Hollowmere.Data.Models;
using Hollowmere.Data.Repositories;
using Hollowmere.Server.DTOs;

using Microsoft.EntityFrameworkCore;

namespace Hollowmere.Server.Services;

public class CreaturesService(CreaturesRepository repository)
{
    public DbResponse<IEnumerable<CreatureDTO>> GetAll()
    {
        var creatures = repository.GetAll().Select(c => c.ToDto());

        return DbResponse<IEnumerable<CreatureDTO>>.Success(creatures);
    }

    public DbResponse<CreatureDTO?> GetById(int id)
    {
        if (repository.GetById(id) is not Creature model)
            return DbResponse<CreatureDTO?>.NotFound();

        return DbResponse<CreatureDTO?>.Success(model.ToDto());
    }

    public async Task<DbResponse<CreatureDTO>> Create(CreatureCreateDTO creature)
    {
        if (repository.Exists(creature.GuildId, creature.Name, creature.Region))
            return DbResponse<CreatureDTO>.Exists();

        try
        {
            var result = repository.Create(creature.FromCreateDTO());
            await repository.SaveChangesAsync();

            return DbResponse<CreatureDTO>.Success(result.ToDto());
        }
        catch (DbUpdateConcurrencyException)
        {
            return DbResponse<CreatureDTO>.Concurrency();
        }
        catch (Exception)
        {
            return DbResponse<CreatureDTO>.Error();
        }
    }

    public async Task<DbResponse<CreatureDTO>> Update(CreatureEditDTO creature)
    {
        if (repository.Exists(creature.GuildId, creature.Name, creature.Region))
            return DbResponse<CreatureDTO>.Exists();

        try
        {
            var result = repository.Update(creature.FromEditDTO());
            await repository.SaveChangesAsync();

            return DbResponse<CreatureDTO>.Success(result.ToDto());
        }
        catch (ArgumentException)
        {
            return DbResponse<CreatureDTO>.NotFound();
        }
        catch (DbUpdateConcurrencyException)
        {
            return DbResponse<CreatureDTO>.Concurrency();
        }
        catch (Exception)
        {
            return DbResponse<CreatureDTO>.Error();
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
