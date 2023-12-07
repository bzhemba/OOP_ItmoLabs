using ATMSystem.Application.Contracts.BankAccounts;
using ATMSystem.Application.Contracts.BankAccounts.WithdrawResults;
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
        AnsiConsole.Prompt(
            new TextPrompt<int>("Enter the withdraw amount")
                .ValidationErrorMessage("[red]Incorrect amount[/]")
                .Validate(amount =>
                {
                    WithdrawResult withdrawResult = _accountService.Withdraw(amount);
                    return withdrawResult switch
                    {
                        InsufficientFunds => ValidationResult.Error("[red]Insufficient funds[/]"),
                        IncorrectAmount => ValidationResult.Error("[red]Incorrect value entered[/]"),
                        _ => ValidationResult.Success(),
                    };
                }));
    }
}