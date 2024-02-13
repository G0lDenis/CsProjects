using Application.Models.Operations;

namespace Application.Abstractions.Repositories;

public interface IOperationArchiveRepository
{
    Task AddOperation(long bankAccountId, long amount, OperationResultState resultState);

    Task<IReadOnlyCollection<Operation>> FindOperationsByBankAccountId(long bankAccountId);
}