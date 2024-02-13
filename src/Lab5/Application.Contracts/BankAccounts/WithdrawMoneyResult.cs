namespace Application.Contracts.BankAccounts;

public abstract record WithdrawMoneyResult
{
    public record WithdrawMoneySuccess : WithdrawMoneyResult;

    public record WithdrawMoneyFail : WithdrawMoneyResult;
}