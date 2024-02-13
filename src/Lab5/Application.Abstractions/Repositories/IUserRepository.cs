using Application.Models.Users;

namespace Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> CreateUser(string name, UserRole userRole);

    Task<User?> FindUserByUserId(long userId);
}