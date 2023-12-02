using AtmSystem.Application.Models.Users;

namespace AtmSystem.Application.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUserById(long userId);
    public void AddUser(long id, string name, string surname);
}