using AtmSystem.Application.Models.Transactions;
using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;

namespace AtmSystem.Infrastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder?.MapEnum<TransactionType>();
    }
}