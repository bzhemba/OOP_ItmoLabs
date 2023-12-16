using ATMSystem.Application.Contracts.BankAccounts;
using Spectre.Console;

namespace AtmSystem.Presentation.Console.Scenarios.DepositIntoAccount;

public class DepositIntoAccountScenario : IScenario
{
    private readonly IBankAccountService _accountService;

    public DepositIntoAccountScenario(IBankAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Deposit into bank account";

    public void Run()
    {
        int amount = AnsiConsole.Ask<int>("Enter the deposit amount");
        _accountService.Deposit(amount);
    }
}