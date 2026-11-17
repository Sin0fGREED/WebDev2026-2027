using Hollowmere.Data.Models;

namespace Hollowmere.Data.Repositories;

public class CreaturesRepository(AppDbContext context)
{
    public IQueryable<Creature> GetAll() =>
        context.Creatures.AsQueryable();

    public Creature? GetById(int id) =>
        context.Creatures.FirstOrDefault(c => c.Id == id);

    public Creature Create(Creature creature)
    {
        context.Creatures.Add(creature);
        return creature;
    }

    public Creature Update(Creature creature)
    {
        var model = GetById(creature.Id)
            ?? throw new ArgumentException($"Creature with id {creature.Id} does not exist.");

        model.Update(creature);

        return creature;
    }

    public bool Delete(int id)
    {
        var model = GetById(id)
            ?? throw new ArgumentException($"Creature with id {id} does not exist.");
        context.Creatures.Remove(model);

        return true;
    }

    public bool Exists(int id) =>
        context.Creatures.Any(c => c.Id == id);

    public bool Exists(Guid guildId, string name, string region) =>
        context.Creatures.Any(c => c.GuildId == guildId && c.Name == name && c.Region == region);

    public Task SaveChangesAsync() =>
        context.SaveChangesAsync();
}
