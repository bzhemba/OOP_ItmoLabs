using ATMSystem.Application.Contracts.BankAccounts;
using AtmSystem.Application.Models.BankAccounts;

namespace ATMSystemApplication.Users;

internal class CurrentAccountManager : ICurrentAccountService
{
    public BankAccount? Account { get; set; }
}