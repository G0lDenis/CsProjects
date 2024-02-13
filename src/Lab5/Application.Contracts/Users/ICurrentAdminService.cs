using Application.Models.Users;

namespace Application.Contracts.Users;

public interface ICurrentAdminService
{
    User? User { get; }
}