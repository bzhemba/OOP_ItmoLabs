using AtmSystem.Application.Abstractions.Repositories;
using ATMSystem.Application.Contracts.BankAccounts;
using ATMSystem.Application.Contracts.BankAccounts.LoginResults;
using ATMSystem.Application.Contracts.BankAccounts.WithdrawResults;
using AtmSystem.Application.Models.BankAccounts;
using AtmSystem.Application.Models.Transactions;
using ATMSystemApplication.Users;

namespace ATMSystemApplication.BankAccounts;

internal class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _repository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly CurrentAccountManager _currentAccountManager;

    public BankAccountService(
    IBankAccountRepository repository,
    ITransactionRepository transactionRepository,
    CurrentAccountManager currentAccountManager)
    {
        _repository = repository;
        _transactionRepository = transactionRepository;
        _currentAccountManager = currentAccountManager;
    }

    public LoginResult Login(long id, int pinCode)
    {
        bool accountExisting = _repository.IsAccountExists(id);

        if (!accountExisting)
        {
            return new NotFound();
        }

        BankAccount? account = _repository.GetAccountByIdAndPin(id, pinCode);
        if (account is null)
        {
            return new WrongPinCode();
        }

        _currentAccountManager.Account = account;
        return new LoginSuccess();
    }

    public bool IsAccountExists(long id)
    {
        return _repository.IsAccountExists(id);
    }

    public BankAccount? GetAccountByIdAndPin(long id, int pinCode)
    {
        return _repository.GetAccountByIdAndPin(id, pinCode);
    }

    public bool CreateAccount(long ownerId, int balance, int pin)
    {
        return _repository.CreateAccount(ownerId, balance, pin);
    }

    public long GetBalance()
    {
        if (_currentAccountManager.Account != null) return _currentAccountManager.Account.Balance;
        throw new ArgumentNullException($"You are not logged into account");
    }

    public WithdrawResult Withdraw(int amount)
    {
        if (_currentAccountManager.Account == null)
            throw new ArgumentException($"You are not logged into account");
        if (amount < 0)
        {
            return new IncorrectAmount();
        }

        if (_currentAccountManager.Account.Balance - amount < 0)
        {
            return new InsufficientFunds();
        }

        int newBalance = _currentAccountManager.Account.Balance - amount;

        _currentAccountManager.Account.UpdateBalance(newBalance);
        _repository.UpdateValue(_currentAccountManager.Account.Id, newBalance, amount, TransactionType.Withdrawal);
        return new WithdrawSuccess();
    }

    public void Deposit(int amount)
    {
        if (_currentAccountManager.Account == null || amount < 0) return;

        int newBalance = _currentAccountManager.Account.Balance + amount;

        _currentAccountManager.Account.UpdateBalance(newBalance);
        _repository.UpdateValue(_currentAccountManager.Account.Id, newBalance, amount, TransactionType.Deposit);
    }

    public IEnumerable<Transaction>? GetTransactionHistory()
    {
        return _currentAccountManager.Account == null ? null : _transactionRepository.GetTransactionHistory(_currentAccountManager.Account.Id);
    }
}