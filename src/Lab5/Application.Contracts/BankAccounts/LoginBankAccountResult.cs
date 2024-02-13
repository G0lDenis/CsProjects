namespace Application.Contracts.BankAccounts;

public abstract record LoginBankAccountResult
{
    public sealed record AccountLoginSuccess : LoginBankAccountResult;

    public sealed record AccountLoginFail : LoginBankAccountResult;
}