using ATMSystem.Application.Contracts.BankAccounts;
using ATMSystem.Application.Contracts.BankAccounts.LoginResults;
using Spectre.Console;

namespace AtmSystem.Presentation.Console.Scenarios.SwitchUserMode;

public class SwitchUserModeScenario : IScenario
{
    private IBankAccountService _accountService;

    public SwitchUserModeScenario(IBankAccountService bankAccountService)
    {
        _accountService = bankAccountService;
    }

    public string Name => "Switch to User mode";
    public void Run()
    {
        long id = AnsiConsole.Prompt(
            new TextPrompt<long>("Enter account number")
                .ValidationErrorMessage("[red]Incorrect account number[/]")
                .Validate(id =>
                {
                    return _accountService.IsAccountExists(id) switch
                    {
                        false => ValidationResult.Error("[red]This account number doesn't exist[/]"),
                        true => ValidationResult.Success(),
                    };
                }));
        AnsiConsole.Prompt(
            new TextPrompt<int>("Enter pin code")
                .PromptStyle("green")
                .Secret('*')
                .ValidationErrorMessage("[red]Incorrect pin code[/]")
                .Validate(pin =>
                {
                    LoginResult loginResult = _accountService.Login(id, pin);
                    return loginResult switch
                    {
                        WrongPinCode => ValidationResult.Error("[red]You've entered wrong pin code[/]"),
                        _ => ValidationResult.Success(),
                    };
                }));
    }
}