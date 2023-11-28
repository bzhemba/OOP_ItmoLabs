using AtmSystem.Application.Abstractions.Repositories;
using ATMSystem.Application.Contracts.Users;
using ATMSystem.Application.Contracts.Users.LoginResults;
using AtmSystem.Application.Models.BankAccounts;

namespace ATMSystemApplication.Users;

internal class UserService : IUserService
{
    private readonly IBankAccountRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IBankAccountRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(long id, string pinCode)
    {
        bool accountExisting = _repository.IsAccountExists(id);

        if (!accountExisting)
        {
            return new NotFound();
        }

        BankAccount? account = _repository.GetAccountByIdAndPin(id, pinCode);
        if (account is null)
        {
            return new WrongPinCode();
        }

        _currentUserManager.Account = account;
        return new Success();
    }
}