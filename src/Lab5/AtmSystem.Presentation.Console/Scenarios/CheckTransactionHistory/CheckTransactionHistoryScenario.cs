using ATMSystem.Application.Contracts.BankAccounts;
using AtmSystem.Application.Models.Transactions;
using Spectre.Console;

namespace AtmSystem.Presentation.Console.Scenarios.CheckTransactionHistory;

public class CheckTransactionHistoryScenario : IScenario
{
    private readonly IBankAccountService _accountService;

    public CheckTransactionHistoryScenario(IBankAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Check account's transaction history";
    public void Run()
    {
        IEnumerable<Transaction>? transactions = _accountService.GetTransactionHistory();
        var table = new Table();
        table.AddColumn("Transaction type").Centered();
        table.AddColumn(new TableColumn("Amount").Centered());
        table.AddColumn(new TableColumn("Date").Centered());
        AnsiConsole.Write(table);
        if (transactions is null) return;
        foreach (Transaction transaction in transactions)
        {
            if (transaction.TransactionType is TransactionType.Deposit)
            {
                table.AddRow("Deposit", $"[green]{transaction.Amount}", $"{transaction.TransactionTime}");
            }

            table.AddRow("Withdraw", $"[red]{transaction.Amount}", $"{transaction.TransactionTime}");
        }

        AnsiConsole.Write(table);
    }
}