using System.Diagnostics.CodeAnalysis;
using ATMSystem.Application.Contracts.BankAccounts;

namespace AtmSystem.Presentation.Console.Scenarios.SwitchUserMode;

public class SwitchUserModeScenarioProvider : IAdminScenarioProvider
{
    private IBankAccountService _accountService;

    public SwitchUserModeScenarioProvider(IBankAccountService accountService)
    {
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new SwitchUserModeScenario(_accountService);
        return true;
    }
}