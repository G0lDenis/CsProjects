using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Readers;

public class ConsoleReader : IReader
{
    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}