using System.Diagnostics.CodeAnalysis;
using Application.Contracts.BankAccounts;

namespace Presentation.Console.Scenarios.BankAccountLogout;

public class BankAccountLogoutScenarioProvider : IScenarioProvider
{
    private readonly ICurrentBankAccountService _currentBankAccountService;
    private readonly IBankAccountService _bankAccountService;

    public BankAccountLogoutScenarioProvider(
        ICurrentBankAccountService currentBankAccountService,
        IBankAccountService bankAccountService)
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

        scenario = new BankAccountLogoutScenario(_bankAccountService);
        return true;
    }
}