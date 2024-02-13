using Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.DepositMoney;

public class DepositMoneyScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public DepositMoneyScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Deposit money";

    public void Run()
    {
        long money = AnsiConsole.Ask<long>("How much do you want to deposit?");

        _bankAccountService.DepositMoney(money);

        string message = "Money successfully deposited";
        AnsiConsole.Prompt(new TextPrompt<string>(message + '\n').Secret(null).AllowEmpty());
    }
}