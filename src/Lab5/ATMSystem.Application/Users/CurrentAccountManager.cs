using ATMSystem.Application.Contracts.BankAccounts;
using AtmSystem.Application.Models.BankAccounts;

namespace ATMSystemApplication.Users;

public class CurrentAccountManager : ICurrentAccountService
{
    public BankAccount? Account { get; set; }
}