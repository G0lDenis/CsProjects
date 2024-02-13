using Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.BankAccountLogout;

public class BankAccountLogoutScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public BankAccountLogoutScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Logout bank account";

    public void Run()
    {
        _bankAccountService.LogoutBankAccount();

        string message = "Logout successfully";
        AnsiConsole.Prompt(new TextPrompt<string>(message + '\n').Secret(null).AllowEmpty());
    }
}