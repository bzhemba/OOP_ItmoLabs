using System.Diagnostics.CodeAnalysis;
using ATMSystem.Application.Contracts.BankAccounts;

namespace AtmSystem.Presentation.Console.Scenarios.DepositIntoAccount;

public class DepositIntoAccountScenarioProvider : IUserScenarioProvider
{
    private readonly IBankAccountService _accountService;
    public DepositIntoAccountScenarioProvider(IBankAccountService accountService)
    {
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new DepositIntoAccountScenario(_accountService);
        return true;
    }
}