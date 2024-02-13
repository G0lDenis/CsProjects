using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;

namespace Presentation.Console.Scenarios.AdminLogout;

public class AdminLogoutScenarioProvider : IScenarioProvider
{
    private readonly ICurrentAdminService _currentAdminService;
    private readonly IAdminService _adminService;

    public AdminLogoutScenarioProvider(
        ICurrentAdminService currentAdminService,
        IAdminService adminService)
    {
        _currentAdminService = currentAdminService;
        _adminService = adminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdminService.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLogoutScenario(_adminService);
        return true;
    }
}