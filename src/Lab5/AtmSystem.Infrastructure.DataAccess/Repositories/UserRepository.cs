using AtmSystem.Application.Abstractions.Repositories;
using AtmSystem.Application.Models.Users;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace AtmSystem.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindUserById(long userId)
    {
        const string sql = """
                           select account_id, account_name
                           from bankUsers
                           where bankUsers.account_id = :userId;
                           """;

        if (_connectionProvider != null)
        {
            Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
            NpgsqlConnection result = connection.GetAwaiter().GetResult();
            using var command = new NpgsqlCommand(sql, result);
            try
            {
                command.AddParameter("userId", userId);
            }
            catch
            {
                result.Dispose();
                throw;
            }

            using NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read() is false)
                return null;

            return new User(
                Id: reader.GetInt64(0),
                Name: reader.GetString(1));
        }

        return null;
    }

    public void AddUser(long id, string name)
    {
        const string sql = """
                           
                            insert into bankUsers (account_id, account_name)
                            values (:id, :name);
                                                  
                           """;

        if (_connectionProvider != null)
        {
            Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
            NpgsqlConnection result = connection.GetAwaiter().GetResult();
            using var command = new NpgsqlCommand(sql, result);
            command.AddParameter("id", id);
            command.AddParameter("name", name);

            command.ExecuteNonQuery();
        }
    }
}