using DbUp;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory))
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var connectionString = config.GetConnectionString("Postgres");
var upgrader = DeployChanges.To
    .PostgresqlDatabase(connectionString)
    .WithScriptsFromFileSystem(Path.Combine(AppContext.BaseDirectory, "sql"))
    .LogToConsole()
    .Build();

var result = upgrader.PerformUpgrade();

Console.WriteLine($"Миграция закончилась успешно: {result.Successful}");

    
