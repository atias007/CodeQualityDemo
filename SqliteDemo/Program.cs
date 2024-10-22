// https://dbeaver.io/download/
// https://www.sqlite.org/cli.html

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SqliteDemo;

var connectionString = "Data Source=mydatabase.db;";
using var connection = new SqliteConnection(connectionString);
await connection.OpenAsync();

await CreateTable(connection);
await InsertData(connection);
await PrintData(connection);

using var db = new MyDbContext();
await InsertDataEF(db);
await PrintDataEF(db);

static async Task CreateTable(SqliteConnection connection)
{
    var query = "CREATE TABLE Person (id INTEGER PRIMARY KEY, name TEXT)";
    var command = new SqliteCommand(query, connection);
    await command.ExecuteNonQueryAsync();
}

static async Task InsertData(SqliteConnection connection)
{
    var query = "INSERT INTO person (name) VALUES ('John')";
    var command = new SqliteCommand(query, connection);
    await command.ExecuteNonQueryAsync();

    query = "INSERT INTO person (name) VALUES (@name)";
    command = new SqliteCommand(query, connection);
    command.Parameters.AddWithValue("@name", "Iron Developer");
    await command.ExecuteNonQueryAsync();
}

static async Task PrintData(SqliteConnection connection)
{
    var query = "SELECT * FROM person";
    var command = new SqliteCommand(query, connection);
    var reader = await command.ExecuteReaderAsync();
    while (reader.Read())
    {
        Console.WriteLine(reader["name"]);
    }
}

static async Task InsertDataEF(MyDbContext db)
{
    db.Persons.Add(new Person { Name = "Israel" });
    db.Persons.Add(new Person { Name = "Avraham" });

    await db.SaveChangesAsync();
}

static async Task PrintDataEF(MyDbContext db)
{
    var data = await db.Persons.ToListAsync();
    foreach (var item in data)
    {
        await Console.Out.WriteLineAsync($"{item.Id} | {item.Name}");
    }
}