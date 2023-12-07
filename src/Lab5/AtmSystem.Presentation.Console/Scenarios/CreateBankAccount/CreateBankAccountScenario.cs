using System.Globalization;
using ATMSystem.Application.Contracts.BankAccounts;
using ATMSystem.Application.Contracts.BankAccounts.ValidatePinResults;
using ATMSystem.Application.Contracts.Users;
using AtmSystem.Application.Models.Users;
using Spectre.Console;

namespace AtmSystem.Presentation.Console.Scenarios.CreateBankAccount;

public class CreateBankAccountScenario : IScenario
{
    private readonly IBankAccountService _accountService;
    private readonly IUserService _userService;

    public CreateBankAccountScenario(IBankAccountService accountService, IUserService userService)
    {
        _accountService = accountService;
        _userService = userService;
    }

    public string Name => "Create new account";

    public void Run()
    {
        string name;
        User? user;
        long id = AnsiConsole.Ask<long>("Enter user's id");
        user = _userService.GetUserById(id);
        if (user is null)
        {
            name = AnsiConsole.Ask<string>("Enter user's name");
            _userService.CreateUser(id, name);
        }

        int pin = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter account pin code")
                .Secret('*')
                .ValidationErrorMessage("[red]Incorrect pin code[/]")
                .Validate(pin =>
                {
                    return ValidatePin(pin.ToString(CultureInfo.InvariantCulture)) switch
                    {
                        IncorrectLength => ValidationResult.Error("[red]Pin must contain 4 digits[/]"),
                        UnaccepatableSymbols => ValidationResult.Error("[red]Pin must contain digits only[/]"),
                        _ => ValidationResult.Success(),
                    };
                }));
        _accountService.CreateAccount(id, 0, pin);
    }

    private static ValidatePinResult ValidatePin(string pin)
    {
        if (pin != null)
        {
            if (pin.Length != 4)
            {
                return new IncorrectLength();
            }

            if (!pin.All(char.IsDigit))
            {
                return new UnaccepatableSymbols();
            }
            else
            {
                return new ValidPin();
            }
        }

        throw new ArgumentException("Pin is an empty string");
    }
}