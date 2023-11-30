namespace ATMSystem.Application.Contracts.Users;

public interface IUserService
{
    bool IsUserExists(long id, string name);
}