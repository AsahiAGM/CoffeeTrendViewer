using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// SQLite database initialization
var dbDirectory = Path.Combine(app.Environment.ContentRootPath, "Database");
Directory.CreateDirectory(dbDirectory);

var dbPath = Path.Combine(dbDirectory, "coffee.db");
var connectionString = $"Data Source={dbPath}";

{
    using var connection = new SqliteConnection(connectionString);
    connection.Open();

    Console.WriteLine($"SQLite connected\n: {dbPath}");
}


app.MapGet("/", () => "Hello World!");

app.Run();
