using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class MessengerConsoleWriter : IMessengerConsoleWriter
{
    public void WriteText(string text)
    {
        Console.WriteLine(text);
    }
}