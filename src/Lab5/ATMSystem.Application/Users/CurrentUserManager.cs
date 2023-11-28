using ATMSystem.Application.Contracts.Users;
using AtmSystem.Application.Models.BankAccounts;

namespace ATMSystemApplication.Users;

internal class CurrentUserManager : ICurrentUserService
{
    public BankAccount? Account { get; set; }
}