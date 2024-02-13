using Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public WithdrawMoneyScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Withdraw money";

    public void Run()
    {
        long money = AnsiConsole.Ask<long>("How much do you want to withdraw?");

        WithdrawMoneyResult result = _bankAccountService.WithdrawMoney(money);

        string message = result switch
        {
            WithdrawMoneyResult.WithdrawMoneySuccess => "Money successfully withdraw",
            WithdrawMoneyResult.WithdrawMoneyFail => "You have no enough money to do this operation",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.Prompt(new TextPrompt<string>(message + '\n').Secret(null).AllowEmpty());
    }
}