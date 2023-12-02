using AtmSystem.Application.Abstractions.Repositories;
using ATMSystem.Application.Contracts.Users;
using AtmSystem.Application.Models.Users;

namespace ATMSystemApplication.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
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