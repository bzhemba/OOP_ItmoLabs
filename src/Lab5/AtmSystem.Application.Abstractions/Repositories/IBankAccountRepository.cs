using AtmSystem.Application.Models.BankAccounts;

namespace AtmSystem.Application.Abstractions.Repositories;

public interface IBankAccountRepository
{
    bool IsAccountExists(long id);
    BankAccount? GetAccountByIdAndPin(long id, string pinCode);
}