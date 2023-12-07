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
        string password = AnsiConsole.Ask<string>("Input new system password");
        if (_adminService.IsPasswordSet())
        {
            string oldPassword = AnsiConsole.Ask<string>("Input old system password");
            if (_adminService.Login(oldPassword) is WrongSystemPassword)
            {
                return;
            }

            _adminService.SetPassword(password);
        }

        _adminService.SetPassword(password);
    }
}