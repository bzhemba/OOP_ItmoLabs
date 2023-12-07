using AtmSystem.Application.Abstractions.Repositories;
using ATMSystem.Application.Contracts.BankAccounts.LoginResults;
using ATMSystem.Application.Contracts.Users;
using AtmSystem.Application.Models.Users;

namespace ATMSystemApplication.Users;

public class AdminService : IAdminService
{
    private readonly IUserRepository _repository;
    private string? _systemPassword;

    public AdminService(IUserRepository repository)
    {
        _repository = repository;
    }

    public LoginResult Login(string systemPassword)
    {
        if (systemPassword != _systemPassword)
        {
            return new WrongSystemPassword();
        }

        return new LoginSuccess();
    }

    public User? GetUserById(long userId)
    {
        User? user = _repository.FindUserById(userId);

        return user;
    }

    public void SetPassword(string password)
    {
            _systemPassword = password;
    }

    public bool IsPasswordSet()
    {
        return _systemPassword != null;
    }

    public void CreateUser(long id, string name)
    {
        _repository.AddUser(id, name);
    }
}