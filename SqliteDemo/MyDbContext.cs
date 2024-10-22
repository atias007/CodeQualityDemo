using Microsoft.EntityFrameworkCore;

namespace SqliteDemo;

public class MyDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=mydatabase.db;");
    }
}