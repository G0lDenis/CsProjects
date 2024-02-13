namespace Application.Contracts.BankAccounts;

public interface IBankAccountService
{
    CreationBankAccountResult CreateBankAccount(string name, long pinCode);

    LoginBankAccountResult LoginBankAccount(long bankAccountCode, long pinCode);

    void LogoutBankAccount();

    void DepositMoney(long money);

    WithdrawMoneyResult WithdrawMoney(long money);

    long? GetCurrentAccountBalance();

    string? GetCurrentAccountName();

    IReadOnlyCollection<OperationView>? GetCurrentAccountOperations();
}