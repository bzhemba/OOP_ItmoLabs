using ATMSystem.Application.Contracts.BankAccounts.LoginResults;
using ATMSystem.Application.Contracts.Users;

namespace ATMSystemApplication.Users;

public class AdminService : IAdminService
{
    private readonly string _systemPassword;

    public AdminService(string systemPassword)
    {
        _systemPassword = systemPassword;
    }

    public LoginResult Login(string systemPassword)
    {
        if (systemPassword != _systemPassword)
        {
            return new WrongSystemPassword();
        }

        return new LoginSuccess();
    }
}