using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class ConsoleWriter : IOutputWriter
{
    public void WriteText(string text)
    {
        Console.WriteLine(text);
    }

    public void ClearOutput()
    {
        Console.Clear();
    }
}