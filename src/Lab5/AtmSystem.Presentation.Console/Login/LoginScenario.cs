using ATMSystem.Application.Contracts.BankAccounts;
using ATMSystem.Application.Contracts.BankAccounts.LoginResults;
using ATMSystem.Application.Contracts.Users;
using Spectre.Console;

namespace AtmSystem.Presentation.Console.Login;

public class LoginScenario : IScenario
{
    private readonly IBankAccountService _accountService;
    private readonly IAdminService _adminService;

    public LoginScenario(IBankAccountService accountService, IAdminService adminService)
    {
        _accountService = accountService;
        _adminService = adminService;
    }

    public string Name => "Login";
    public void Run()
    {
        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select mode[/]")
                .PageSize(10)
                .AddChoices(new[] { "Admin", "User" }));
        if (choice == "User")
        {
            long id = AnsiConsole.Ask<long>("Enter account number");
            AnsiConsole.Prompt(
                new TextPrompt<int>("Enter pin code")
                    .PromptStyle("green")
                    .Secret('*')
                    .ValidationErrorMessage("[red]Incorrect pin code or account number[/]")
                    .Validate(pin =>
                    {
                        LoginResult loginResult = _accountService.Login(id, pin);
                        return loginResult switch
                        {
                            NotFound => ValidationResult.Error("[red]This account number doesn't exist[/]"),
                            WrongPinCode => ValidationResult.Error("[red]You've entered wrong pin code[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));
        }

        if (choice == "Admin")
        {
            string password = AnsiConsole.Ask<string>("Enter system password");
            if (_adminService.Login(password) is WrongSystemPassword)
            {
                return;
            }
        }
    }
}