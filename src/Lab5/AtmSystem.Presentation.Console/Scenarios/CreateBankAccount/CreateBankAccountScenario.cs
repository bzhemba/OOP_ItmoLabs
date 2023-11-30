using ATMSystem.Application.Contracts.BankAccounts;
using Spectre.Console;

namespace AtmSystem.Presentation.Console.Scenarios.CreateBankAccount;

public class CreateBankAccountScenario : IScenario
{
    private readonly IBankAccountService _accountService;

    public CreateBankAccountScenario(IBankAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Create new account";

    public void Run()
    {
        long username = AnsiConsole.Ask<string>("Enter username");
        AnsiConsole.WriteLine($"You selected {shop.Name}");
        AnsiConsole.Ask<string>("");
    }
}