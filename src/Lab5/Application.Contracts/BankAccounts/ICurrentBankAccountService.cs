using Application.Models.BankAccounts;

namespace Application.Contracts.BankAccounts;

public interface ICurrentBankAccountService
{
    BankAccount? BankAccount { get; }
}