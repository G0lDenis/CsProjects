using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receiver;

public class GroupReceiver : IReceiver
{
    private readonly IReadOnlyList<IReceiver> _receivers;

    public GroupReceiver(IReadOnlyList<IReceiver> receivers)
    {
        _receivers = receivers;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IReceiver receiver in _receivers)
        {
            receiver.ReceiveMessage(message);
        }
    }
}