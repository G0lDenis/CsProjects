using Application.Application.BankAccounts;
using Application.Application.Users;
using Application.Contracts.BankAccounts;
using Application.Contracts.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IBankAccountService, BankAccountService>();
        collection.AddScoped<IAdminService, AdminService>();

        collection.AddScoped<CurrentBankAccountManager>();
        collection.AddScoped<ICurrentBankAccountService>(
            p => p.GetRequiredService<CurrentBankAccountManager>());

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        collection.AddScoped<CurrentAdminManager>();
        collection.AddScoped<ICurrentAdminService>(
            p => p.GetRequiredService<CurrentAdminManager>());

        return collection;
    }
}