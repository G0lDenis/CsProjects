namespace Application.Contracts.Users;

public interface IAdminService
{
    LoginAdminResult LoginAdmin(long adminId, long passCode);

    void Logout();
}