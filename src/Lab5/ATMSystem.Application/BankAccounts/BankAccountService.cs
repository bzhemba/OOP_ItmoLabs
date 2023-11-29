using AtmSystem.Application.Abstractions.Repositories;
using ATMSystem.Application.Contracts.BankAccounts;
using AtmSystem.Application.Models.BankAccounts;

namespace ATMSystemApplication.BankAccounts;

internal class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _repository;

    public BankAccountService(IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public bool IsAccountExists(long id)
    {
        return _repository.IsAccountExists(id);
    }

    public BankAccount? GetAccountByIdAndPin(long id, string pinCode)
    {
        return _repository.GetAccountByIdAndPin(id, pinCode);
    }

    public bool CreateAccount(BankAccount account)
    {
        return _repository.CreateAccount(account);
    }

    public long GetBalance(long id)
    {
        return _repository.GetBalance(id);
    }

    public bool Withdraw(long id, decimal amount)
    {
        return _repository.Withdraw(id, amount);
    }

    public bool Deposit(long id, decimal amount)
    {
        return _repository.Deposit(id, amount);
    }
}