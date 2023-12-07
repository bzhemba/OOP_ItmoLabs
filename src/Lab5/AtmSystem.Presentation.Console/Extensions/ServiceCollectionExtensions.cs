using AtmSystem.Presentation.Console.Login;
using AtmSystem.Presentation.Console.Scenarios.CheckBalance;
using AtmSystem.Presentation.Console.Scenarios.CheckTransactionHistory;
using AtmSystem.Presentation.Console.Scenarios.CreateBankAccount;
using AtmSystem.Presentation.Console.Scenarios.DepositIntoAccount;
using AtmSystem.Presentation.Console.Scenarios.SetSystemPassword;
using AtmSystem.Presentation.Console.Scenarios.WithdrawFromAccount;
using Microsoft.Extensions.DependencyInjection;

namespace AtmSystem.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<LoginUserScenarioProvider>();
        collection.AddScoped<LoginAdminScenarioProvider>();

        collection.AddScoped<IUserScenarioProvider, CheckBalanceScenarioProvider>();
        collection.AddScoped<IUserScenarioProvider, CheckTransactionHistoryScenarioProvider>();
        collection.AddScoped<IAdminScenarioProvider, CreateBankAccountScenarioProvider>();
        collection.AddScoped<IUserScenarioProvider, DepositIntoAccountScenarioProvider>();
        collection.AddScoped<IAdminScenarioProvider, SetSystemPasswordScenarioProvider>();
        collection.AddScoped<IUserScenarioProvider, WithdrawFromAccountScenarioProvider>();

        return collection;
    }
}