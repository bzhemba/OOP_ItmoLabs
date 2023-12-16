using AtmSystem.Application.Models.BankAccounts;

namespace ATMSystem.Application.Contracts.BankAccounts;

public interface ICurrentAccountService
{
    BankAccount? Account { get; }
}