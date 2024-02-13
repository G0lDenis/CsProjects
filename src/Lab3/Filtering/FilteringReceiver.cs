using Itmo.ObjectOrientedProgramming.Lab3.Receiver;

namespace Itmo.ObjectOrientedProgramming.Lab3.Filtering;

public class FilteringReceiver : IReceiver
{
    private readonly IReceiver _receiver;
    private readonly int _minimumRequiredPriority;

    public FilteringReceiver(IReceiver receiver, int minimumRequiredPriority)
    {
        _receiver = receiver;
        _minimumRequiredPriority = minimumRequiredPriority;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.Priority < _minimumRequiredPriority)
            return;
        _receiver.ReceiveMessage(message);
    }
}