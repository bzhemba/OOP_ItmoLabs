using ATMSystem.Application.Contracts.BankAccounts;
using Spectre.Console;

namespace AtmSystem.Presentation.Console.Scenarios.CheckBalance;

public class CheckBalanceScenario : IScenario
{
    private readonly IBankAccountService _accountService;

    public CheckBalanceScenario(IBankAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Check account's balance";
    public void Run()
    {
        AnsiConsole.Write($"[bold]Current balance:[/] {_accountService.GetBalance()}");
    }
}