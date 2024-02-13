using Application.Abstractions.Repositories;
using Application.Contracts.BankAccounts;
using Application.Models.Operations;
using Application.Models.Users;

namespace Application.Application.BankAccounts;

public class BankAccountService : IBankAccountService
{
    private readonly CurrentUserManager _currentUserManager;
    private readonly CurrentBankAccountManager _currentBankAccountManager;
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly IUserRepository _userRepository;
    private readonly IOperationArchiveRepository _operationArchiveRepository;

    public BankAccountService(
        CurrentUserManager currentUserManager,
        CurrentBankAccountManager currentBankAccountManager,
        IBankAccountRepository bankAccountRepository,
        IUserRepository userRepository,
        IOperationArchiveRepository operationArchiveRepository)
    {
        _currentUserManager = currentUserManager;
        _currentBankAccountManager = currentBankAccountManager;
        _bankAccountRepository = bankAccountRepository;
        _userRepository = userRepository;
        _operationArchiveRepository = operationArchiveRepository;
    }

    public CreationBankAccountResult CreateBankAccount(string name, long pinCode)
    {
        Task.Run(
            async () =>
            {
                _currentUserManager.User ??= await _userRepository.CreateUser(name, UserRole.Client).ConfigureAwait(false);
            }).GetAwaiter().GetResult();

        if (_currentUserManager.User is null)
            return new CreationBankAccountResult.AccountCreationFail();

        Task.Run(
            async () =>
            {
                _currentBankAccountManager.BankAccount = await _bankAccountRepository.CreateBankAccount(_currentUserManager.User.UserId, pinCode).ConfigureAwait(false);
            }).GetAwaiter().GetResult();

        if (_currentBankAccountManager.BankAccount is null)
            return new CreationBankAccountResult.AccountCreationFail();

        return new CreationBankAccountResult.AccountCreationSuccess();
    }

    public LoginBankAccountResult LoginBankAccount(long bankAccountCode, long pinCode)
    {
        Task.Run(
            async () =>
            {
                _currentBankAccountManager.BankAccount = await _bankAccountRepository.FindAccountByCodeAndPinCode(bankAccountCode, pinCode).ConfigureAwait(false);
            }).GetAwaiter().GetResult();

        if (_currentBankAccountManager.BankAccount is null)
            return new LoginBankAccountResult.AccountLoginFail();

        Task.Run(
            async () =>
            {
                _currentUserManager.User = await _userRepository.FindUserByUserId(_currentBankAccountManager.BankAccount.UserId).ConfigureAwait(false);
            }).GetAwaiter().GetResult();

        return new LoginBankAccountResult.AccountLoginSuccess();
    }

    public void LogoutBankAccount()
    {
        _currentBankAccountManager.BankAccount = null;
        _currentUserManager.User = null;
    }

    public void DepositMoney(long money)
    {
        Task.Run(
            async () =>
            {
                if (_currentBankAccountManager.BankAccount is null)
                    return;
                long newMoneyAmount = _currentBankAccountManager.BankAccount.Amount + money;
                await _bankAccountRepository.SetMoneyAmount(_currentBankAccountManager.BankAccount.BankAccountId, newMoneyAmount).ConfigureAwait(false);

                await _operationArchiveRepository.AddOperation(_currentBankAccountManager.BankAccount.BankAccountId, money, OperationResultState.Success).ConfigureAwait(false);
            }).GetAwaiter().GetResult();
        UpdateCurrentBankAccount();
    }

    public WithdrawMoneyResult WithdrawMoney(long money)
    {
        if (_currentBankAccountManager.BankAccount is null)
            return new WithdrawMoneyResult.WithdrawMoneyFail();

        if (_currentBankAccountManager.BankAccount.Amount < money)
        {
            Task.Run(
                async () =>
                {
                    await _operationArchiveRepository.AddOperation(_currentBankAccountManager.BankAccount.BankAccountId, -money, OperationResultState.Fail).ConfigureAwait(false);
                }).GetAwaiter().GetResult();

            return new WithdrawMoneyResult.WithdrawMoneyFail();
        }

        Task.Run(
            async () =>
            {
                long newMoneyAmount = _currentBankAccountManager.BankAccount.Amount - money;
                await _bankAccountRepository.SetMoneyAmount(_currentBankAccountManager.BankAccount.BankAccountId, newMoneyAmount).ConfigureAwait(false);

                await _operationArchiveRepository.AddOperation(_currentBankAccountManager.BankAccount.BankAccountId, -money, OperationResultState.Success).ConfigureAwait(false);
                UpdateCurrentBankAccount();
            }).GetAwaiter().GetResult();

        return new WithdrawMoneyResult.WithdrawMoneySuccess();
    }

    public long? GetCurrentAccountBalance()
    {
        return _currentBankAccountManager.BankAccount?.Amount;
    }

    public string? GetCurrentAccountName()
    {
        return _currentUserManager.User?.UserName;
    }

    public IReadOnlyCollection<OperationView>? GetCurrentAccountOperations()
    {
        if (_currentBankAccountManager.BankAccount is null)
            return null;

        var operations = new List<OperationView>();

        Task.Run(
            async () =>
            {
                foreach (Operation operation in await _operationArchiveRepository.FindOperationsByBankAccountId(_currentBankAccountManager.BankAccount.BankAccountId).ConfigureAwait(false))
                {
                    operations.Add(new OperationView(
                        Amount: operation.Amount,
                        ResultState: operation.ResultState));
                }

                UpdateCurrentBankAccount();
            }).GetAwaiter().GetResult();

        return operations;
    }

    private void UpdateCurrentBankAccount()
    {
        if (_currentBankAccountManager.BankAccount is null)
            return;

        Task.Run(
            async () =>
            {
                _currentBankAccountManager.BankAccount = await
                    _bankAccountRepository
                        .FindAccountByCodeAndPinCode(
                            _currentBankAccountManager.BankAccount.BankAccountCode,
                            _currentBankAccountManager.BankAccount.PinCode).ConfigureAwait(false);
            }).GetAwaiter().GetResult();
    }
}