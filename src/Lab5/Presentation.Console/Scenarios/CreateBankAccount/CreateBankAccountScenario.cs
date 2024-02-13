using Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.CreateBankAccount;

public class CreateBankAccountScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public CreateBankAccountScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Create bank account";

    public void Run()
    {
        string name = AnsiConsole.Ask<string>("What is your name?");
        long pinCode = AnsiConsole.Prompt(new TextPrompt<long>("Enter your future pin-code"));

        CreationBankAccountResult result = _bankAccountService.CreateBankAccount(name, pinCode);

        string message = result switch
        {
            CreationBankAccountResult.AccountCreationSuccess => "Successfully created account",
            CreationBankAccountResult.AccountCreationFail => "Failed to create account with such name",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.Prompt(new TextPrompt<string>(message + '\n').Secret(null).AllowEmpty());
    }
}