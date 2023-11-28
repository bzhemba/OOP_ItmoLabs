using ATMSystem.Application.Contracts.Users.LoginResults;

namespace ATMSystem.Application.Contracts.Users;

public interface IAdminService
{
    LoginResult Login(string systemPassword);
}