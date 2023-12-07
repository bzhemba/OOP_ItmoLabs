using ATMSystem.Application.Contracts.BankAccounts.LoginResults;
using ATMSystem.Application.Contracts.Users;
using Spectre.Console;

namespace AtmSystem.Presentation.Console.Scenarios.SetSystemPassword;

public class SetSystemPasswordScenario : IScenario
{
    private readonly IAdminService _adminService;

    public SetSystemPasswordScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Set system password";

    public void Run()
    {
        if (_adminService.IsPasswordSet())
        {
            string oldPassword = AnsiConsole.Ask<string>("Input old system password");
            if (_adminService.Login(oldPassword) is WrongSystemPassword)
            {
                return;
            }

            string password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter new system password")
                    .ValidationErrorMessage("[red]Incorrect password[/]")
                    .Validate(password =>
                    {
                        return password.Length switch
                        {
                             < 4 => ValidationResult.Error("[red]Password must contain at least 4 symbols[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));
            _adminService.SetPassword(password);
        }
        else
        {
            string password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter new system password")
                    .ValidationErrorMessage("[red]Incorrect password[/]")
                    .Validate(password =>
                    {
                        return password.Length switch
                        {
                            < 4 => ValidationResult.Error("[red]Password must contain at least 4 symbols[/]"),
                            > 10 => ValidationResult.Error("[red]Password must contain no more than 10 symbols[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));
            _adminService.SetPassword(password);
        }
    }
}