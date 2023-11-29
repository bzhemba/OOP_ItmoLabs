using AtmSystem.Application.Models.BankAccounts;

namespace ATMSystem.Application.Contracts.BankAccounts;

public interface IBankAccountService
{
    bool IsAccountExists(long id);
    BankAccount? GetAccountByIdAndPin(long id, string pinCode);
    bool CreateAccount(BankAccount account);
    long GetBalance(long id);
    bool Withdraw(long id, decimal amount);
    bool Deposit(long id, decimal amount);
}