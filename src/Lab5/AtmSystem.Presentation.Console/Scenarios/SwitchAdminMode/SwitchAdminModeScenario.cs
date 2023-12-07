using ATMSystem.Application.Contracts.BankAccounts.LoginResults;
using ATMSystem.Application.Contracts.Users;
using Spectre.Console;

namespace AtmSystem.Presentation.Console.Scenarios.SwitchAdminMode;

public class SwitchAdminModeScenario : IScenario
{
    private IAdminService _adminService;

    public SwitchAdminModeScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Switch to Admin mode";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter system password");
        if (_adminService.Login(password) is LoginSuccess)
        {
            return;
        }

        throw new ArgumentException();
    }
}