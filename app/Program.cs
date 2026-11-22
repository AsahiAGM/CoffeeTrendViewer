using Microsoft.AspNetCore.Http.Features;
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
        Console.WriteLine($"Verified table: {reader["name"]}");
    }
    else
    {
        Console.WriteLine("Table not found.");
    }

    // test INSERT database
    Console.WriteLine();

    var coffeeLog = GetCoffeeLog();
    if(InsertLog(connection, coffeeLog) > 0)
    {
        Console.WriteLine("INSERT succeeded.");
    }
    else
    {
        Console.WriteLine("INSERT NOTHING");
    }

    // test read database
    Console.WriteLine();
    using var selectCommand = connection.CreateCommand();

   selectCommand.CommandText = """
        SELECT Id, CoffeeName, Rating
        FROM CoffeeLogs;
    """;

    using var secondReader = selectCommand.ExecuteReader();

    Console.WriteLine("---CoffeeLogs---");
    while(secondReader.Read())
    {
        Console.WriteLine($"Id[{secondReader["Id"]}] {secondReader["CoffeeName"]} rating: {secondReader["Rating"]}");
    }

    // end
    Console.WriteLine();

}


app.MapGet("/", () => "Hello World!");

app.Run();

// local method
string GetCoffeeName()
{
    string? usersInput = "";

    while(string.IsNullOrWhiteSpace(usersInput))
    {
        Console.WriteLine("\nPlease write favorite coffee name.");
        usersInput = Console.ReadLine();
    }

    return usersInput.Trim();
}

int GetRating()
{
    string? usersRating;
    bool isInvalidItem = true;
    int rating = -1;

    while(isInvalidItem)
    {
        Console.WriteLine("how would you rate this coffee? please provide a rating on a scale of 1 to 5.");
        usersRating = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(usersRating))
        {
            Console.WriteLine("invalid input. please agein");
            continue;
        }
        if(int.TryParse(usersRating, out rating))
        {
            if(rating >= 1 && rating <= 5)
            {
                isInvalidItem = false;
            }
            else
            {
                Console.WriteLine("please provide a rating on a scale of 1 to 5.");
            }
        }
        else
        {
            Console.WriteLine("invalid input. please again");
        }
    }

    return rating;
}

CoffeeLog GetCoffeeLog()
{
    var usersInput = GetCoffeeName();
    var usersRating = GetRating();

    return new CoffeeLog(usersInput, usersRating);
}

int InsertLog(SqliteConnection connection, CoffeeLog coffeeLog)
{
    using var insertCommand = connection.CreateCommand();

    insertCommand.CommandText = """
        INSERT INTO CoffeeLogs (CoffeeName, Rating)
        VALUES (@CoffeeName, @Rating);
    """;

    // read users input and insert   
    insertCommand.Parameters.AddWithValue("@CoffeeName", coffeeLog.CoffeeName);
    insertCommand.Parameters.AddWithValue("@Rating", coffeeLog.Rating);

    return insertCommand.ExecuteNonQuery();
}