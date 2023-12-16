using AtmSystem.Application.Models.Transactions;

namespace ATMSystem.Application.Contracts.Transactions;

public interface ITransactionService
{
    IEnumerable<Transaction> GetTransactionHistory(long id);
}