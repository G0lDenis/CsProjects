using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class ConsoleMessageLogger : IMessageLogger
{
    public void Log(Message message)
    {
        Console.WriteLine("Message logged: " + message.Title);
    }
}