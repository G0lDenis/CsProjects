using Itmo.ObjectOrientedProgramming.Lab3.Receiver;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class LoggingReceiver : IReceiver
{
    private readonly IReceiver _receiver;
    private readonly IMessageLogger _logger;

    public LoggingReceiver(IReceiver receiver, IMessageLogger logger)
    {
        _receiver = receiver;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        _logger.Log(message);
        _receiver.ReceiveMessage(message);
    }
}