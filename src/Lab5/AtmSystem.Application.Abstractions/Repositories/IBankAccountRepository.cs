using AtmSystem.Application.Models.BankAccounts;
using AtmSystem.Application.Models.Transactions;

namespace AtmSystem.Application.Abstractions.Repositories;

public interface IBankAccountRepository
{
    bool IsAccountExists(long id);
    BankAccount? GetAccountByIdAndPin(long id, string pinCode);
    bool CreateAccount(BankAccount account);
    void UpdateValue(long id, int newBalance, TransactionType transactionType);
}