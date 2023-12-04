using AtmSystem.Application.Abstractions.Repositories;
using ATMSystem.Application.Contracts.BankAccounts.LoginResults;
using ATMSystem.Application.Contracts.Users;
using AtmSystem.Application.Models.Users;

namespace ATMSystemApplication.Users;

public class AdminService : IUserService
{
    private readonly string _systemPassword;
    private readonly IUserRepository _repository;

    public AdminService(string systemPassword, IUserRepository repository)
    {
        _systemPassword = systemPassword;
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

    public void CreateUser(long id, string name, string surname)
    {
        _repository.AddUser(id, name, surname);
    }
}