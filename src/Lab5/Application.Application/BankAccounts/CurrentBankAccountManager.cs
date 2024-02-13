using Application.Contracts.BankAccounts;
using Application.Models.BankAccounts;

namespace Application.Application.BankAccounts;

public class CurrentBankAccountManager : ICurrentBankAccountService
{
    public BankAccount? BankAccount { get; set; }
}