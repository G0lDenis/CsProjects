using Microsoft.Extensions.DependencyInjection;
using Presentation.Console.Scenarios;
using Presentation.Console.Scenarios.AdminLogin;
using Presentation.Console.Scenarios.AdminLogout;
using Presentation.Console.Scenarios.BankAccountLogin;
using Presentation.Console.Scenarios.BankAccountLogout;
using Presentation.Console.Scenarios.CreateBankAccount;
using Presentation.Console.Scenarios.DepositMoney;
using Presentation.Console.Scenarios.OperationsView;
using Presentation.Console.Scenarios.ShowCurrentAccountBalance;
using Presentation.Console.Scenarios.WithdrawMoney;

namespace Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, BankAccountLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, BankAccountLogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateBankAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowCurrentAccountBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, OperationViewScenarioProvider>();

        return collection;
    }
}