namespace Application.Contracts.Users;

public abstract record LoginAdminResult
{
    public sealed record LoginAdminSuccess : LoginAdminResult;

    public sealed record LoginAdminFail : LoginAdminResult;
}