using Hollowmere.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace Hollowmere.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Creature> Creatures => Set<Creature>();
    public DbSet<Drill> Drills => Set<Drill>();
    public DbSet<DrillParticipant> DrillParticipants => Set<DrillParticipant>();
    public DbSet<Encounter> Encounters => Set<Encounter>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<ItemKind> ItemKinds => Set<ItemKind>();
    public DbSet<ItemQualification> ItemQualifications => Set<ItemQualification>();
    public DbSet<Loan> Loans => Set<Loan>();
    public DbSet<Quest> Quests => Set<Quest>();
    public DbSet<Report> Reports => Set<Report>();
    public DbSet<Request> Requests => Set<Request>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
