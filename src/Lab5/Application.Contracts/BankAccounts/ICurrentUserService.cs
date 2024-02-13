using Application.Models.Users;

namespace Application.Contracts.BankAccounts;

public interface ICurrentUserService
{
    User? User { get; }
}
