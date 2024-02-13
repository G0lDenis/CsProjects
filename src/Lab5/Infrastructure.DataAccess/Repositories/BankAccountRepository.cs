using Application.Abstractions.Repositories;
using Application.Models.BankAccounts;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<BankAccount?> CreateBankAccount(long userId, long pinCode)
    {
        const string sql = """
                           insert into bank_accounts
                           values(default, :user_id, default, :pin_code, 0)
                           returning bank_account_id, user_id, bank_account_code, pin_code, amount
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("user_id", userId);
            command.AddParameter("pin_code", pinCode);

            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (await reader.ReadAsync().ConfigureAwait(false) is false)
                    return null;

                return new BankAccount(
                    BankAccountId: reader.GetInt64(0),
                    UserId: reader.GetInt64(1),
                    BankAccountCode: reader.GetInt64(2),
                    PinCode: reader.GetInt64(3),
                    Amount: reader.GetInt64(4));
            }
        }
    }

    public async Task<BankAccount?> FindAccountByCodeAndPinCode(long bankAccountCode, long pinCode)
    {
        const string sql = """
                           select bank_account_id, user_id, bank_account_code, pin_code, amount
                           from bank_accounts
                           where bank_account_code = :bank_account_code
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("bank_account_code", bankAccountCode);
            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (await reader.ReadAsync().ConfigureAwait(false) is false)
                    return null;

                long correctPinCode = reader.GetInt64(3);
                if (correctPinCode != pinCode)
                    return null;

                return new BankAccount(
                    BankAccountId: reader.GetInt64(0),
                    UserId: reader.GetInt64(1),
                    BankAccountCode: reader.GetInt64(2),
                    PinCode: correctPinCode,
                    Amount: reader.GetInt64(4));
            }
        }
    }

    public async Task SetMoneyAmount(long bankAccountId, long amount)
    {
        const string sql = """
                           update bank_accounts
                           set amount = :amount
                           where bank_account_id= :bank_account_id;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("amount", amount);
            command.AddParameter("bank_account_id", bankAccountId);

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }
}