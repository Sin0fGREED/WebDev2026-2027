using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Hollowmere.Data.Tests;

public static class DbFactory
{
    public static (AppDbContext Context, SqliteConnection Connection) Create()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new AppDbContext(options);
        context.Database.EnsureCreated();

        return (context, connection);
    }
}
