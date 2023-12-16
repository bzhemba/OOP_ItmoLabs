using System.Diagnostics.CodeAnalysis;
using ATMSystem.Application.Contracts.BankAccounts;

namespace AtmSystem.Presentation.Console.Login;

public class LoginUserScenarioProvider : IUserScenarioProvider
{
    private readonly IBankAccountService _accountService;
    private readonly ICurrentAccountService _currentAccountService;

    public LoginUserScenarioProvider(
        ICurrentAccountService currentAccountService,
        IBankAccountService accountService)
    {
        _currentAccountService = currentAccountService;
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccountService.Account is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginUserScenario(_accountService);
        return true;
    }
}