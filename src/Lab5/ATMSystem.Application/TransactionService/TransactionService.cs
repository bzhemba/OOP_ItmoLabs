using AtmSystem.Application.Abstractions.Repositories;
using ATMSystem.Application.Contracts.Transactions;
using AtmSystem.Application.Models.Transactions;

namespace ATMSystemApplication.TransactionService;

internal class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;

    public TransactionService(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Transaction> GetTransactionHistory(long id)
    {
        return _repository.GetTransactionHistory(id);
    }
}