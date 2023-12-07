using ATMSystem.Application.Contracts.BankAccounts.LoginResults;
using ATMSystem.Application.Contracts.Users;
using Spectre.Console;

namespace AtmSystem.Presentation.Console.Login;

public class LoginAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LoginAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login";
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