using AtmSystem.Application.Abstractions.Repositories;
using ATMSystem.Application.Contracts.BankAccounts.WithdrawResults;
using AtmSystem.Application.Models.BankAccounts;
using AtmSystem.Application.Models.Transactions;
using ATMSystemApplication.BankAccounts;
using ATMSystemApplication.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class ATMSystemTests
{
    [Fact]
    public void WithdrawMoneyWithSuccessTest()
    {
        IBankAccountRepository? accountRepository = Substitute.For<IBankAccountRepository>();
        ITransactionRepository? transactionRepository = Substitute.For<ITransactionRepository>();
        var accountManager = new CurrentAccountManager();
        var bankAccountService = new BankAccountService(accountRepository, transactionRepository, accountManager);
        accountManager.Account = new BankAccount(123456, 12, 1234, 100);
        accountRepository.UpdateValue(123456, 12, 1234, TransactionType.Withdrawal);
        bankAccountService.Withdraw(10);
        int currentBalance = bankAccountService.GetBalance();
        Assert.Equal(90, currentBalance);
    }

    [Fact]
    public void WithdrawMoneyWithFailureTest()
    {
        IBankAccountRepository? accountRepository = Substitute.For<IBankAccountRepository>();
        ITransactionRepository? transactionRepository = Substitute.For<ITransactionRepository>();
        var accountManager = new CurrentAccountManager();
        var bankAccountService = new BankAccountService(accountRepository, transactionRepository, accountManager);
        accountManager.Account = new BankAccount(123456, 12, 1234, 100);
        accountRepository.UpdateValue(123456, 12, 1234, TransactionType.Withdrawal);
        WithdrawResult withdrawResult = bankAccountService.Withdraw(101);
        bool result = withdrawResult is InsufficientFunds;
        Assert.True(result);
    }

    [Fact]
    public void DepositTest()
    {
        IBankAccountRepository? accountRepository = Substitute.For<IBankAccountRepository>();
        ITransactionRepository? transactionRepository = Substitute.For<ITransactionRepository>();
        var accountManager = new CurrentAccountManager();
        var bankAccountService = new BankAccountService(accountRepository, transactionRepository, accountManager);
        accountManager.Account = new BankAccount(123456, 12, 1234, 100);
        accountRepository.UpdateValue(123456, 12, 1234, TransactionType.Withdrawal);
        bankAccountService.Deposit(100);
        int currentBalance = bankAccountService.GetBalance();
        Assert.Equal(200, currentBalance);
    }
}