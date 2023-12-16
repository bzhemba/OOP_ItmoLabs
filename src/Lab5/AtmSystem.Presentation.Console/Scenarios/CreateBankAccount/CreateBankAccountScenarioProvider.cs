using System.Diagnostics.CodeAnalysis;
using ATMSystem.Application.Contracts.BankAccounts;
using ATMSystem.Application.Contracts.Users;

namespace AtmSystem.Presentation.Console.Scenarios.CreateBankAccount;

public class CreateBankAccountScenarioProvider : IAdminScenarioProvider
{
    private readonly IBankAccountService _accountService;
    private readonly IUserService _userService;

    public CreateBankAccountScenarioProvider(IBankAccountService accountService, IUserService userService)
    {
        _accountService = accountService;
        _userService = userService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new CreateBankAccountScenario(_accountService, _userService);
        return true;
    }
}