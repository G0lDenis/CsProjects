using Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.BankAccountLogin;

public class BankAccountLoginScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public BankAccountLoginScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Login Your bank account";

    public void Run()
    {
        long accountCode = AnsiConsole.Ask<long>("Enter account code");
        long pinCode = AnsiConsole.Prompt(new TextPrompt<long>("Enter pin-code").Secret());

        LoginBankAccountResult result = _bankAccountService.LoginBankAccount(accountCode, pinCode);

        string message = result switch
        {
            LoginBankAccountResult.AccountLoginSuccess => $"Successfully login account {_bankAccountService.GetCurrentAccountName()}",
            LoginBankAccountResult.AccountLoginFail => "Wrong bank account code or pin-code",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.Prompt(new TextPrompt<string>(message + '\n').Secret(null).AllowEmpty());
    }
}