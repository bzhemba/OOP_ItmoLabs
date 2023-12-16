using AtmSystem.Application.Abstractions.Repositories;
using AtmSystem.Application.Models.BankAccounts;
using AtmSystem.Application.Models.Transactions;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace AtmSystem.Infrastructure.DataAccess.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public bool IsAccountExists(long id)
    {
        const string sql = """
                           select account_id, account_owner, account_balance, account_pin
                           from accounts
                           where account_id = :id;
                           """;

        if (_connectionProvider != null)
        {
            Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
            NpgsqlConnection result = connection.GetAwaiter().GetResult();
            using var command = new NpgsqlCommand(sql, result);
            command.AddParameter("id", id);

            using NpgsqlDataReader reader = command.ExecuteReader();

            return reader.Read();
        }

        return false;
    }

    public BankAccount? GetAccountByIdAndPin(long id, int pinCode)
    {
        const string sql = """
                           select account_id, account_owner, account_balance, account_pin
                           from accounts
                           where account_id = :id and account_pin = :pinCode;
                           """;

        if (_connectionProvider != null)
        {
            Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
            NpgsqlConnection result = connection.GetAwaiter().GetResult();
            using var command = new NpgsqlCommand(sql, result);
            command.AddParameter("id", id)
                    .AddParameter("pinCode", pinCode);

            using NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read() is false)
                return null;

            return new BankAccount(
                id: reader.GetInt64(0),
                ownerId: reader.GetInt64(1),
                pinCode: reader.GetInt32(ordinal: 2),
                balance: reader.GetInt32(3));
        }

        return null;
    }

    public bool CreateAccount(long ownerId, int balance, int pin)
    {
        const string sql = """
                           
                                                  insert into accounts (account_owner, account_balance, account_pin)
                                                  values (:ownerId, :balance, :pin);
                                                  
                           """;

        if (_connectionProvider != null)
        {
            Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
            NpgsqlConnection result = connection.GetAwaiter().GetResult();
            using var command = new NpgsqlCommand(sql, result);
            command.AddParameter("ownerId", ownerId);
            command.AddParameter("balance", balance);
            command.AddParameter("pin", pin);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        return false;
    }

    public void UpdateValue(long id, int newBalance, int amount, TransactionType transactionType)
    {
        const string sql = """
                                                  UPDATE accounts
                                                  SET account_balance = :newBalance
                                                  WHERE account_id = :id;
                                                  INSERT INTO TransactionHistory (account_id, transaction_type, transaction_amount, transaction_date)
                                                  VALUES (:id, :transactionType, :amount, NOW());
                           """;

        if (_connectionProvider == null) return;
        Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
        NpgsqlConnection result = connection.GetAwaiter().GetResult();
        using var command = new NpgsqlCommand(sql, result);
        command.AddParameter("newBalance", newBalance);
        command.AddParameter("transactionType", transactionType);
        command.AddParameter("amount", amount);
        command.AddParameter("id", id);

        int rowsAffected = command.ExecuteNonQuery();
    }
}