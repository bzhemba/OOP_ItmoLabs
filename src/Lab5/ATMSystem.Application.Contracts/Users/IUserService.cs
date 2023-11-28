using ATMSystem.Application.Contracts.Users.LoginResults;

namespace ATMSystem.Application.Contracts.Users;

public interface IUserService
{
    LoginResult Login(long id, string pinCode);
}