using ATMSystem.Application.Contracts.BankAccounts.LoginResults;
using ATMSystem.Application.Contracts.BankAccounts.WithdrawResults;
using AtmSystem.Application.Models.BankAccounts;

namespace ATMSystem.Application.Contracts.BankAccounts;

public interface IBankAccountService
{
    bool IsAccountExists(long id);
    BankAccount? GetAccountByIdAndPin(long id, string pinCode);
    bool CreateAccount(BankAccount account);
    long GetBalance();
    WithdrawResult Withdraw(int amount);
    void Deposit(int amount);
    LoginResult Login(long id, string pinCode);
}