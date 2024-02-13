namespace Itmo.ObjectOrientedProgramming.Lab3;

public class MessageRenderer
{
    private readonly Message _message;

    public MessageRenderer(Message message)
    {
        _message = message;
    }

    public string Render()
    {
        return _message.Title
               + '\n'
               + _message.Body;
    }
}