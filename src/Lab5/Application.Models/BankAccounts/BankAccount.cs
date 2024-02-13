namespace Application.Models.BankAccounts;

public record BankAccount(long BankAccountId, long UserId, long BankAccountCode, long PinCode, long Amount);