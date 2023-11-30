using ATMSystem.Application.Contracts.BankAccounts.LoginResults;

namespace ATMSystem.Application.Contracts.Users;

public interface IAdminService
{
    LoginResult Login(string systemPassword);
}