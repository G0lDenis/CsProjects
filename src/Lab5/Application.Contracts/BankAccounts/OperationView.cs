using Application.Models.Operations;

namespace Application.Contracts.BankAccounts;

public record OperationView(long Amount, OperationResultState ResultState);