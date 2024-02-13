namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Messenger : IMessenger
{
    private readonly IMessengerConsoleWriter _writer;

    public Messenger(IMessengerConsoleWriter writer)
    {
        _writer = writer;
    }

    public void GetMessage(Message message)
    {
        _writer.WriteText("message: " + new MessageRenderer(message).Render());
    }
}