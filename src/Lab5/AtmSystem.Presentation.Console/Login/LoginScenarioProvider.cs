using System.Diagnostics.CodeAnalysis;
using ATMSystem.Application.Contracts.BankAccounts;
using ATMSystem.Application.Contracts.Users;

namespace AtmSystem.Presentation.Console.Login;

public class LoginScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountService _accountService;
    private readonly IAdminService _adminService;
    private readonly ICurrentAccountService _currentAccountService;

    public LoginScenarioProvider(
        ICurrentAccountService currentAccountService,
        IAdminService adminService,
        IBankAccountService accountService)
    {
        _currentAccountService = currentAccountService;
        _adminService = adminService;
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

        scenario = new LoginScenario(_accountService, _adminService);
        return true;
    }
}