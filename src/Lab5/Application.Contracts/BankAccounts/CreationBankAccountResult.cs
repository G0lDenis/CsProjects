namespace Application.Contracts.BankAccounts;

public abstract record CreationBankAccountResult
{
    public sealed record AccountCreationSuccess : CreationBankAccountResult;

    public sealed record AccountCreationFail : CreationBankAccountResult;
}