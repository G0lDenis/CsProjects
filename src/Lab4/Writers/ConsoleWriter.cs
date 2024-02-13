using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Writers;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string text)
    {
        Console.Write(text);
    }

    public void Clear()
    {
        Console.Clear();
    }
}