using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.AdminLogin;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLoginScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login Admin panel";

    public void Run()
    {
        long adminCode = AnsiConsole.Ask<long>("Enter admin id");
        long pinCode = AnsiConsole.Prompt(new TextPrompt<long>("Enter pin-code").Secret());

        LoginAdminResult result = _adminService.LoginAdmin(adminCode, pinCode);

        string message = result switch
        {
            LoginAdminResult.LoginAdminSuccess => "Successfully login admin panel",
            LoginAdminResult.LoginAdminFail => "Wrong id or pin-code",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.Prompt(new TextPrompt<string>(message + '\n').Secret(null).AllowEmpty());
    }
}