using Application.Abstractions.Repositories;
using Application.Models.Users;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> CreateUser(string name, UserRole userRole)
    {
        const string sql = """
                           insert into users
                           values(default, :user_name, :user_role)
                           returning user_id, user_name, user_role
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("user_name", name);
            command.AddParameter("user_role", userRole);

            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (await reader.ReadAsync().ConfigureAwait(false) is false)
                    return null;

                return new User(
                    UserId: reader.GetInt64(0),
                    UserName: reader.GetString(1),
                    UserRole: userRole);
            }
        }
    }

    public async Task<User?> FindUserByUserId(long userId)
    {
        const string sql = """
                           select user_id, user_name, user_role
                           from users
                           where user_id = :user_id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("user_id", userId);
            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (await reader.ReadAsync().ConfigureAwait(false) is false)
                    return null;

                UserRole userRole = await reader.GetFieldValueAsync<UserRole>(3).ConfigureAwait(false);

                return new User(
                    UserId: reader.GetInt64(0),
                    UserName: reader.GetString(1),
                    UserRole: userRole);
            }
        }
    }
}