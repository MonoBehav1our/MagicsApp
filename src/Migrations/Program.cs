using DbUp;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=sc;Database=postgres;";
var upgrader = DeployChanges.To
    .PostgresqlDatabase(connectionString)
    .WithScriptsFromFileSystem(Path.Combine(AppContext.BaseDirectory, "sql"))
    .LogToConsole()
    .Build();

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
    return 1;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();

return 0;

    
