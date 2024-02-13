namespace Itmo.ObjectOrientedProgramming.Lab3.Receiver;

public class MessengerReceiver : IReceiver
{
    private readonly IMessenger _messenger;

    public MessengerReceiver(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(Message message)
    {
        _messenger.GetMessage(message);
    }
}