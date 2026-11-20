using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// SQLite database initialization
var dbDirectory = Path.Combine(app.Environment.ContentRootPath, "Database");
Directory.CreateDirectory(dbDirectory);

var dbPath = Path.Combine(dbDirectory, "coffee.db");
var connectionString = $"Data Source={dbPath}";

{
    // set connection
    using var connection = new SqliteConnection(connectionString);
    connection.Open();

    Console.WriteLine($"SQLite connected. Path[{dbPath}]\n");

    // set command
    using var command = connection.CreateCommand();

    command.CommandText = """
        CREATE TABLE IF NOT EXISTS CoffeeLogs(
            Id INTEGER PRIMARY KEY,
            CoffeeName TEXT NOT NULL,
            Rating INTEGER
        );
    """;

    command.ExecuteNonQuery();

    // test read database
    using var verifyCommand = connection.CreateCommand();

    verifyCommand.CommandText = """
        SELECT name
        FROM sqlite_master
        WHERE type = 'table'
            AND name = 'CoffeeLogs';
    """;

    using var reader = verifyCommand.ExecuteReader();

    if(reader.Read())
    {
        Console.WriteLine($"Verified table: {reader["name"]}\n");
    }
    else
    {
        Console.WriteLine("Table not found.\n");
    }
}


app.MapGet("/", () => "Hello World!");

app.Run();
