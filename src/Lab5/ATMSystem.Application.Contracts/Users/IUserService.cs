using AtmSystem.Application.Models.Users;

namespace ATMSystem.Application.Contracts.Users;

public interface IUserService
{
    User? GetUserById(long userId);
    public void CreateUser(long id, string name);
}