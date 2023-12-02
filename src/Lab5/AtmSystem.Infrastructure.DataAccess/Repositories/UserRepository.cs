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
                           select user_id, user_name, user_surname
                           from users
                           where user_id = :userId;
                           """;

        if (_connectionProvider != null)
        {
            Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
            NpgsqlConnection result = connection.GetAwaiter().GetResult();
            using var command = new NpgsqlCommand(sql, result);
            try
            {
                command.AddParameter("id", userId);
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
                Name: reader.GetString(1),
                Surname: reader.GetString(2));
        }

        return null;
    }

    public void AddUser(long id, string name, string surname)
    {
        const string sql = """
                           
                            insert into accounts (user_id, user_name, user_surname)
                            values (:id,:name, :surname);
                                                  
                           """;

        if (_connectionProvider != null)
        {
            Task<NpgsqlConnection> connection = _connectionProvider.GetConnectionAsync(default).AsTask();
            NpgsqlConnection result = connection.GetAwaiter().GetResult();
            using var command = new NpgsqlCommand(sql, result);
            try
            {
                command.AddParameter("name", name);
                command.AddParameter("surname", surname);
            }
            catch
            {
                result.Dispose();
                throw;
            }

            command.ExecuteNonQuery();
        }
    }
}