using Itmo.ObjectOrientedProgramming.Lab3.Receiver;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public class Topic
{
    private readonly IReceiver _receiver;

    public Topic(string name, IReceiver receiver)
    {
        _receiver = receiver;
        Name = name;
    }

    public string Name { get; }

    public void SendMessage(Message message)
    {
        _receiver.ReceiveMessage(message);
    }
}