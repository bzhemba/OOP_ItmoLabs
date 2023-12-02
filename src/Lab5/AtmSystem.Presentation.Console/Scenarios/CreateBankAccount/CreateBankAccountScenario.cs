using ATMSystem.Application.Contracts.BankAccounts;
using ATMSystem.Application.Contracts.Users;
using AtmSystem.Application.Models.Users;
using Spectre.Console;

namespace AtmSystem.Presentation.Console.Scenarios.CreateBankAccount;

public class CreateBankAccountScenario : IScenario
{
    private readonly IBankAccountService _accountService;
    private readonly IUserService _userService;

    public CreateBankAccountScenario(IBankAccountService accountService, IUserService userService)
    {
        _accountService = accountService;
        _userService = userService;
    }

    public string Name => "Create new account";

    public void Run()
    {
        string name;
        string surname;
        User? user;
        long id = AnsiConsole.Ask<long>("Enter user's id");
        user = _userService.GetUserById(id);
        if (user is null)
        {
            name = AnsiConsole.Ask<string>("Enter user's name");
            surname = AnsiConsole.Ask<string>("Enter user's surname");
            _userService.CreateUser(id, name, surname);
        }

        int pin = AnsiConsole.Ask<int>("Enter account pin code");
        _accountService.CreateAccount(id, 0, pin);
    }
}