using AtmSystem.Application.Models.BankAccounts;
using AtmSystem.Application.Models.Transactions;

namespace AtmSystem.Application.Abstractions.Repositories;

public interface IBankAccountRepository
{
    bool IsAccountExists(long id);
    BankAccount? GetAccountByIdAndPin(long id, int pinCode);
    public bool CreateAccount(long ownerId, int balance, int pin);
    void UpdateValue(long id, int newBalance, int amount, TransactionType transactionType);
}