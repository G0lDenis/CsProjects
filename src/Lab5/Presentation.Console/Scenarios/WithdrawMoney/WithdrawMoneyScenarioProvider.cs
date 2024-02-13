using System.Diagnostics.CodeAnalysis;
using Application.Contracts.BankAccounts;

namespace Presentation.Console.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenarioProvider : IScenarioProvider
{
    private readonly ICurrentBankAccountService _currentBankAccountService;
    private readonly IBankAccountService _bankAccountService;

    public WithdrawMoneyScenarioProvider(ICurrentBankAccountService currentBankAccountService, IBankAccountService bankAccountService)
    {
        _currentBankAccountService = currentBankAccountService;
        _bankAccountService = bankAccountService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentBankAccountService.BankAccount is null)
        {
            scenario = null;
            return false;
        }

        scenario = new WithdrawMoneyScenario(_bankAccountService);
        return true;
    }
}