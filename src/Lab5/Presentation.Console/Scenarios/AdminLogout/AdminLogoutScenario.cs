using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.AdminLogout;

public class AdminLogoutScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLogoutScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login admin panel";

    public void Run()
    {
        _adminService.Logout();

        string message = "Logout successfully";
        AnsiConsole.Prompt(new TextPrompt<string>(message + '\n').Secret(null).AllowEmpty());
    }
}