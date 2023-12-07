using ATMSystem.Application.Contracts.BankAccounts.LoginResults;
using AtmSystem.Application.Models.Users;

namespace ATMSystem.Application.Contracts.Users;

public interface IAdminService
{
    LoginResult Login(string systemPassword);
    public void SetPassword(string password);
    public void CreateUser(long id, string name, string surname);
    public User? GetUserById(long userId);
    public bool IsPasswordSet();
}