using AtmSystem.Application.Models.BankAccounts;

namespace AtmSystem.Application.Abstractions.Repositories;

public interface IBankAccountRepository
{
    bool IsAccountExists(long id);
    BankAccount? GetAccountByIdAndPin(long id, string pinCode);
    long GetBalance(long id);
    bool CreateAccount(BankAccount account);
    bool Withdraw(long id, decimal amount);
    bool Deposit(long id, decimal amount);
}