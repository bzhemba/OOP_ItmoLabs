using AtmSystem.Application.Abstractions.Repositories;
using ATMSystem.Application.Contracts.Users;
using AtmSystem.Application.Models.BankAccounts;

namespace ATMSystemApplication.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public bool IsUserExists(long id, string name)
    {
    }
}