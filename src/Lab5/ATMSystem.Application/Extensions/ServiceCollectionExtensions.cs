using ATMSystem.Application.Contracts.BankAccounts;
using ATMSystem.Application.Contracts.Transactions;
using ATMSystem.Application.Contracts.Users;
using ATMSystemApplication.BankAccounts;
using ATMSystemApplication.Users;
using Microsoft.Extensions.DependencyInjection;

namespace ATMSystemApplication.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<ITransactionService, TransactionService.TransactionService>();
        collection.AddScoped<IBankAccountService, BankAccountService>();
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<IUserService, UserService>();

        collection.AddScoped<CurrentAccountManager>();
        collection.AddScoped<ICurrentAccountService>(
            p => p.GetRequiredService<CurrentAccountManager>());

        return collection;
    }
}