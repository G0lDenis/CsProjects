using Application.Models.BankAccounts;

namespace Application.Abstractions.Repositories;

public interface IBankAccountRepository
{
    Task<BankAccount?> CreateBankAccount(long userId, long pinCode);

    Task<BankAccount?> FindAccountByCodeAndPinCode(long bankAccountCode, long pinCode);

    Task SetMoneyAmount(long bankAccountId, long amount);
}