using System.Diagnostics.CodeAnalysis;
using ATMSystem.Application.Contracts.BankAccounts;

namespace AtmSystem.Presentation.Console.Scenarios.WithdrawFromAccount;

public class WithdrawFromAccountScenarioProvider : IUserScenarioProvider
{
    private readonly IBankAccountService _accountService;

    public WithdrawFromAccountScenarioProvider(IBankAccountService accountService)
    {
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new WithdrawFromAccountScenario(_accountService);
        return true;
    }
}