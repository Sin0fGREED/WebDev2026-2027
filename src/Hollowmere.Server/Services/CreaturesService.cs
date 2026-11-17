using Hollowmere.Data.Models;
using Hollowmere.Data.Repositories;

namespace Hollowmere.Server.Services;

public class CreaturesService(CreaturesRepository repository)
{
    public IEnumerable<Creature> GetAll()
    {
        return [.. repository.GetAll()];
    }

    public Creature? GetById(int id)
    {
        return repository.GetById(id);
    }

    public async Task<Creature> Create(Creature creature)
    {
        repository.Create(creature);
        await repository.SaveChangesAsync();
        return creature;
    }

    public Creature Update(Creature creature)
    {
        var model = repository.Update(creature);

        return creature;
    }


}
