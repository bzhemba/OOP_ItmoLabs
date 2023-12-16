using AtmSystem.Application.Models.Transactions;

namespace AtmSystem.Application.Abstractions.Repositories;

public interface ITransactionRepository
{
    IEnumerable<Transaction> GetTransactionHistory(long id);
}