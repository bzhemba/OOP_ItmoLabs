using AtmSystem.Application.Abstractions.Repositories;
using AtmSystem.Application.Models.BankAccounts;
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
            try
            {
                command.AddParameter("id", id);
            }
            catch
            {
                result.Dispose();
                throw;
            }

            using NpgsqlDataReader reader = command.ExecuteReader();

            return reader.Read();
        }

        return false;
    }

    public BankAccount? GetAccountByIdAndPin(long id, string pinCode)
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
            try
            {
                command.AddParameter("id", id)
                    .AddParameter("pin", pinCode);
            }
            catch
            {
                result.Dispose();
                throw;
            }

            using NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read() is false)
                return null;

            return new BankAccount(
                Id: reader.GetInt64(0),
                OwnerId: reader.GetInt64(1),
                Balance: reader.GetInt32(2),
                PinCode: reader.GetInt32(ordinal: 3));
        }

        return null;
    }

    public long GetBalance(long id)
    {
        const string sql = """
                           
                                                  SELECT account_balance
                                                  FROM accounts
                                                  WHERE account_id = :id;
                                                  
                           """;

        long balance = 0;

        if (_connectionProvider == null) return balance;
        Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
        NpgsqlConnection result = connection.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, result);
        try
        {
            command.AddParameter("id", id);
        }
        catch
        {
            result.Dispose();
            throw;
        }

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            balance = reader.GetInt64(0);
        }

        return balance;
    }

    public bool CreateAccount(BankAccount account)
    {
        const string sql = """
                           
                                                  insert into accounts (account_id, account_owner, account_balance, account_pin)
                                                  values (:id, :owner, :balance, :pin);
                                                  
                           """;

        if (_connectionProvider != null)
        {
            Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
            NpgsqlConnection result = connection.GetAwaiter().GetResult();
            using var command = new NpgsqlCommand(sql, result);
            try
            {
                if (account != null)
                {
                    command.AddParameter("id", account.Id);
                    command.AddParameter("owner", account.OwnerId);
                    command.AddParameter("balance", account.Balance);
                    command.AddParameter("pin", account.PinCode);
                }
            }
            catch
            {
                result.Dispose();
                throw;
            }

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        return false;
    }

    public bool Withdraw(long id, decimal amount)
    {
        const string sql = """
                           
                                                  UPDATE accounts
                                                  SET account_balance = account_balance - :amount
                                                  WHERE account_id = :id;
                                                  INSERT INTO TransactionHistory (account_id, transaction_type, transaction_amount)
                                                  VALUES (:id, 'withdraw', :amount);
                                                  
                           """;

        if (_connectionProvider != null)
        {
            Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
            NpgsqlConnection result = connection.GetAwaiter().GetResult();
            using var command = new NpgsqlCommand(sql, result);
            try
            {
                command.AddParameter("amount", amount);
                command.AddParameter("id", id);
            }
            catch
            {
                result.Dispose();
                throw;
            }

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        return false;
    }

    public bool Deposit(long id, decimal amount)
    {
        const string sql = """
                           
                                                  UPDATE accounts
                                                  SET account_balance = account_balance + :amount
                                                  WHERE account_id = :id;
                                                  INSERT INTO TransactionHistory (account_id, transaction_type, transaction_amount)
                                                  VALUES (:id, 'deposit', :amount);
                                                  
                           """;

        if (_connectionProvider == null) return false;
        Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
        NpgsqlConnection result = connection.GetAwaiter().GetResult();
        using var command = new NpgsqlCommand(sql, result);
        try
        {
            command.AddParameter("amount", amount);
            command.AddParameter("id", id);
        }
        catch
        {
            result.Dispose();
            throw;
        }

        int rowsAffected = command.ExecuteNonQuery();

        return rowsAffected > 0;
    }
}