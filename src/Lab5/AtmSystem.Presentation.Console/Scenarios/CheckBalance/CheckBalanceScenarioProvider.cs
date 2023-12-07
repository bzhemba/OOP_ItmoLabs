using System.Diagnostics.CodeAnalysis;
using ATMSystem.Application.Contracts.BankAccounts;

namespace AtmSystem.Presentation.Console.Scenarios.CheckBalance;

public class CheckBalanceScenarioProvider : IUserScenarioProvider
{
    private readonly IBankAccountService _accountService;

    public CheckBalanceScenarioProvider(
        IBankAccountService accountService)
    {
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new CheckBalanceScenario(_accountService);
        return true;
    }
}