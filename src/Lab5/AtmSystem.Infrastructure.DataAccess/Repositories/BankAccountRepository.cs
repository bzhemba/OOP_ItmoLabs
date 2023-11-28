using System.Collections.Generic;
using System.Threading.Tasks;
using AtmSystem.Application.Abstractions.Repositories;
using AtmSystem.Application.Models.BankAccounts;
using AtmSystem.Application.Models.Transactions;
using AtmSystem.Application.Models.Users;
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
                           from users
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
                           from users
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
                Owner: reader.GetFieldValue<User>(1),
                Balance: reader.GetInt32(2),
                PinCode: reader.GetInt32(ordinal: 3));
        }

        return null;
    }

    public decimal GetBalance(long id)
    {
        const string sql = """
                           
                                                  SELECT account_balance
                                                  FROM users
                                                  WHERE account_id = :id;
                                                  
                           """;

        decimal balance = 0;

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
            balance = reader.GetDecimal(0);
        }

        return balance;
    }

    public bool CreateAccount(BankAccount account)
    {
        const string sql = """
                           
                                                  insert into users (account_id, account_owner, account_balance, account_pin)
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
                    command.AddParameter("owner", account.Owner);
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
        const string sql = @"
                       UPDATE users
                       SET account_balance = account_balance - :amount
                       WHERE account_id = :id;
                       INSERT INTO TransactionHistory (account_id, transaction_type, transaction_amount)
                       VALUES (:id, 'Withdraw', :amount);
                       ";

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
        const string sql = @"
                       UPDATE users
                       SET account_balance = account_balance + :amount
                       WHERE account_id = :id;
                       INSERT INTO TransactionHistory (account_id, transaction_type, transaction_amount)
                       VALUES (:id, 'Deposit', :amount);
                       ";

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

    public List<Transaction> GetTransactionHistory(long id)
    {
        const string sql = """
                           
                                                  SELECT transaction_id, transaction_type, transaction_amount, transaction_date
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

            while (reader.Read())
            {
                Transaction transaction = new Transaction
                {
                    TransactionId = reader.GetInt32(0),
                    TransactionType = reader.GetString(1),
                    TransactionAmount = reader.GetDecimal(2),
                    TransactionDate = reader.GetDateTime(3)
                };

                transactions.Add(transaction);
            }
        }

        return transactions;
    }

}