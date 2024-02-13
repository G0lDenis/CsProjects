using Application.Contracts.BankAccounts;
using Application.Models.Users;

namespace Application.Application.BankAccounts;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}