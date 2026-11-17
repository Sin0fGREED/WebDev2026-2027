using Hollowmere.Data.Models;

namespace Hollowmere.Data.Repositories;

public class CreaturesRepository(AppDbContext context)
{
    public IEnumerable<Creature> GetAll()
    {
        return context.Creatures;
    }
    public Creature? GetById(int id)
    {
        return context.Creatures.FirstOrDefault(c => c.Id == id);
    }

    public Creature Create(Creature creature)
    {
        context.Creatures.Add(creature);
        return creature;
    }

    public Creature Update(Creature creature)
    {
        var model = GetById(creature.Id);
        if (model is null)
        {
            throw new ArgumentException($"Creature with id {creature.Id} does not exist.");
        }

        model.Name = creature.Name;
        model.Region = creature.Region;
        model.Description = creature.Description;
        model.IsDangerous = creature.IsDangerous;
        model.ImageUri = creature.ImageUri;

        context.Creatures.Update(creature);

        return creature;
    }

    public Creature Delete(int id)
    {
        var model = GetById(id);
        if (model is null)
        {
            throw new ArgumentException($"Creature with id {id} does not exist.");
        }
        context.Creatures.Remove(model);

        return model;
    }

    public Task SaveChangesAsync() => context.SaveChangesAsync();
}
