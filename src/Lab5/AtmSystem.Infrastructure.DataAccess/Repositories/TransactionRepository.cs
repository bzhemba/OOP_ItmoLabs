using AtmSystem.Application.Abstractions.Repositories;
using AtmSystem.Application.Models.Transactions;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace AtmSystem.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Transaction> GetTransactionHistory(long id)
    {
        const string sql = """
                                                  SELECT transaction_id, account_id, transaction_type, transaction_amount, transaction_date
                                                  FROM TransactionHistory
                                                  WHERE account_id = :id
                                                  ORDER BY transaction_date DESC
                                                  
                           """;

        var transactions = new List<Transaction>();

        if (_connectionProvider != null)
        {
            Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
            NpgsqlConnection result = connection.GetAwaiter().GetResult();
            using var command = new NpgsqlCommand(sql, result);
            command.AddParameter("id", id);

            using NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var transaction = new Transaction(
                    TransactionId: reader.GetInt32(0),
                    AccountId: reader.GetInt64(1),
                    TransactionType: reader.GetFieldValue<TransactionType>(2),
                    Amount: reader.GetInt32(ordinal: 3),
                    TransactionTime: reader.GetDateTime(4));

                transactions.Add(transaction);
            }
        }

        return transactions;
    }
}