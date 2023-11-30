using AtmSystem.Application.Models.Users;

namespace AtmSystem.Application.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUserByUsername(string username);
}