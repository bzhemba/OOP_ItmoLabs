using System.Diagnostics.CodeAnalysis;
using ATMSystem.Application.Contracts.BankAccounts;

namespace AtmSystem.Presentation.Console.Scenarios.CheckTransactionHistory;

public class CheckTransactionHistoryScenarioProvider : IUserScenarioProvider
{
    private readonly IBankAccountService _accountService;

    public CheckTransactionHistoryScenarioProvider(IBankAccountService accountService)
    {
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new CheckTransactionHistoryScenario(_accountService);
        return true;
    }
}