using AtmSystem.Application.Abstractions.Repositories;
using AtmSystem.Infrastructure.DataAccess.Plugins;
using AtmSystem.Infrastructure.DataAccess.Repositories;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.Extensions.DependencyInjection;

namespace AtmSystem.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);
        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddScoped<IBankAccountRepository, BankAccountRepository>();
        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<ITransactionRepository, TransactionRepository>();

        return collection;
    }
}