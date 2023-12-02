using ATMSystem.Application.Contracts.BankAccounts;
using Spectre.Console;

namespace AtmSystem.Presentation.Console.Scenarios.WithdrawFromAccount;

public class WithdrawFromAccountScenario : IScenario
{
    private readonly IBankAccountService _accountService;

    public WithdrawFromAccountScenario(IBankAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Withdraw from bank account";

    public void Run()
    {
        int amount = AnsiConsole.Ask<int>("Enter the withdraw amount");
        _accountService.Withdraw(amount);
    }
}