using Application.Contracts.Users;
using Application.Models.Users;

namespace Application.Application.Users;

public class CurrentAdminManager : ICurrentAdminService
{
    public User? User { get; set; }
}