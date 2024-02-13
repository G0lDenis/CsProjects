using System.Diagnostics.CodeAnalysis;
using Application.Contracts.BankAccounts;
using Application.Contracts.Users;

namespace Presentation.Console.Scenarios.BankAccountLogin;

public class BankAccountLoginScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly ICurrentAdminService _currentAdminService;
    private readonly IBankAccountService _bankAccountService;

    public BankAccountLoginScenarioProvider(
        ICurrentUserService currentUserService,
        ICurrentAdminService currentAdminService,
        IBankAccountService bankAccountService)
    {
        _currentUserService = currentUserService;
        _currentAdminService = currentAdminService;
        _bankAccountService = bankAccountService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is not null || _currentAdminService.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new BankAccountLoginScenario(_bankAccountService);
        return true;
    }
}