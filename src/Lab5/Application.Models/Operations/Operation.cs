namespace Application.Models.Operations;

public record Operation(long OperationId, long BankAccountId, long Amount, OperationResultState ResultState);