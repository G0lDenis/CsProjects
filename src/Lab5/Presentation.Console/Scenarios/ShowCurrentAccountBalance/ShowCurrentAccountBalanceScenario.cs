using Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.ShowCurrentAccountBalance;

public class ShowCurrentAccountBalanceScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public ShowCurrentAccountBalanceScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Show account balance";

    public void Run()
    {
        long? balance = _bankAccountService.GetCurrentAccountBalance();
        string message = $"Your current balance is {balance} $";

        AnsiConsole.Prompt(new TextPrompt<string>(message + '\n').Secret(null).AllowEmpty());
    }
}