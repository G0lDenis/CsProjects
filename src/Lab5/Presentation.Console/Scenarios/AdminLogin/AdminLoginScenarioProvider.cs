using System.Diagnostics.CodeAnalysis;
using Application.Contracts.BankAccounts;
using Application.Contracts.Users;

namespace Presentation.Console.Scenarios.AdminLogin;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly ICurrentAdminService _currentAdminService;
    private readonly IAdminService _adminService;

    public AdminLoginScenarioProvider(
        ICurrentUserService currentUserService,
        ICurrentAdminService currentAdminService,
        IAdminService adminService)
    {
        _currentUserService = currentUserService;
        _currentAdminService = currentAdminService;
        _adminService = adminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdminService.User is not null || _currentUserService.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_adminService);
        return true;
    }
}