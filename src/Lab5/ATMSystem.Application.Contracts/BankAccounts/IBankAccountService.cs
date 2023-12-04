using ATMSystem.Application.Contracts.BankAccounts.LoginResults;
using ATMSystem.Application.Contracts.BankAccounts.WithdrawResults;
using AtmSystem.Application.Models.BankAccounts;
using AtmSystem.Application.Models.Transactions;

namespace ATMSystem.Application.Contracts.BankAccounts;

public interface IBankAccountService
{
    bool IsAccountExists(long id);
    BankAccount? GetAccountByIdAndPin(long id, int pinCode);
    public bool CreateAccount(long ownerId, int balance, int pin);
    long GetBalance();
    WithdrawResult Withdraw(int amount);
    void Deposit(int amount);
    LoginResult Login(long id, int pinCode);
    public IEnumerable<Transaction>? GetTransactionHistory();
}