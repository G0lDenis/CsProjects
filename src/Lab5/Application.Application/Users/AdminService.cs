using Application.Abstractions.Repositories;
using Application.Contracts.Users;
using Application.Models.Users;

namespace Application.Application.Users;

public class AdminService : IAdminService
{
    private const long AdminPassword = 12345678;

    private readonly CurrentAdminManager _currentAdminManager;
    private readonly IUserRepository _userRepository;

    public AdminService(CurrentAdminManager currentAdminManager, IUserRepository userRepository)
    {
        _currentAdminManager = currentAdminManager;
        _userRepository = userRepository;
    }

    public LoginAdminResult LoginAdmin(long adminId, long passCode)
    {
        Task.Run(
            async () =>
            {
                _currentAdminManager.User = await _userRepository.FindUserByUserId(adminId).ConfigureAwait(false);
            }).GetAwaiter().GetResult();

        if (_currentAdminManager.User is null || _currentAdminManager.User.UserRole is not UserRole.Admin || passCode != AdminPassword)
        {
            _currentAdminManager.User = null;

            return new LoginAdminResult.LoginAdminFail();
        }

        return new LoginAdminResult.LoginAdminSuccess();
    }

    public void Logout()
    {
        _currentAdminManager.User = null;
    }
}