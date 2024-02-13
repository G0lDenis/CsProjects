using Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.OperationsView;

public class OperationViewScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public OperationViewScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "View operations";

    public void Run()
    {
        IReadOnlyCollection<OperationView>? operations = _bankAccountService.GetCurrentAccountOperations();
        if (operations is null)
            return;

        AnsiConsole.WriteLine("Operations list:");

        foreach (OperationView operation in operations)
        {
            AnsiConsole.WriteLine($"{operation.Amount} {operation.ResultState}");
        }

        AnsiConsole.Prompt(new TextPrompt<string>(string.Empty).Secret(null).AllowEmpty());
    }
}