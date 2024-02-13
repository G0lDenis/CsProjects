namespace Itmo.ObjectOrientedProgramming.Lab3.Receiver;

public class UserReceiver : IReceiver
{
    private readonly IUser _user;

    public UserReceiver(IUser user)
    {
        _user = user;
    }

    public void ReceiveMessage(Message message)
    {
        _user.GetMessage(message);
    }
}