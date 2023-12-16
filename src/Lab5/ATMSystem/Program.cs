using AtmSystem.Infrastructure.DataAccess.Extensions;
using AtmSystem.Presentation.Console;
using AtmSystem.Presentation.Console.Extensions;
using ATMSystemApplication.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace ATMSystem;

internal class Program
{
    public static void Main()
    {
        var collection = new ServiceCollection();

        collection
            .AddApplication()
            .AddInfrastructureDataAccess(configuration =>
            {
                configuration.Host = "localhost";
                configuration.Port = 5434;
                configuration.Username = "postgres";
                configuration.Password = "123";
                configuration.Database = "postgres";
                configuration.SslMode = "Prefer";
            })
            .AddPresentationConsole();
        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        scope.UseInfrastructureDataAccess();

        ScenarioRunner scenarioRunner = scope.ServiceProvider
            .GetRequiredService<ScenarioRunner>();

        IScenario? systemPasswordScenario = scenarioRunner.GetSystemPasswordScenario();
        systemPasswordScenario?.Run();
        AnsiConsole.Clear();
        string[] choices = { "Admin", "User" };
        SelectionPrompt<string> selector = new SelectionPrompt<string>()
            .Title("Select mode")
            .PageSize(10)
            .AddChoices(choices);
        string choice = AnsiConsole.Prompt(selector);
        while (true)
        {
            scenarioRunner.Run(choice);
        }
    }
}