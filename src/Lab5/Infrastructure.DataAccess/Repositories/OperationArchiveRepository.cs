using Application.Abstractions.Repositories;
using Application.Models.Operations;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class OperationArchiveRepository : IOperationArchiveRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationArchiveRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task AddOperation(long bankAccountId, long amount, OperationResultState resultState)
    {
        const string sql = """
                           insert into operation_history
                           values (default, :bank_account_id, :amount, :result_state)
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("bank_account_id", bankAccountId);
            command.AddParameter("amount", amount);
            command.AddParameter("result_state", resultState);

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }

    public async Task<IReadOnlyCollection<Operation>> FindOperationsByBankAccountId(long bankAccountId)
    {
        const string sql = """
                           select operation_id, bank_account_id, amount, result_state
                           from operation_history
                           where bank_account_id = :bank_account_id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("bank_account_id", bankAccountId);

            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                var operations = new List<Operation>();
                while (await reader.ReadAsync().ConfigureAwait(false))
                {
                    OperationResultState resultState = await reader.GetFieldValueAsync<OperationResultState>(3).ConfigureAwait(false);

                    operations.Add(new Operation(
                        OperationId: reader.GetInt64(0),
                        BankAccountId: reader.GetInt64(1),
                        Amount: reader.GetInt64(2),
                        ResultState: resultState));
                }

                return operations;
            }
        }
    }
}