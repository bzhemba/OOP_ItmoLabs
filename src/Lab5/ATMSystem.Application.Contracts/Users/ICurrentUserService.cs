using AtmSystem.Application.Models.BankAccounts;

namespace ATMSystem.Application.Contracts.Users;

public interface ICurrentUserService
{
    BankAccount? Account { get; }
}