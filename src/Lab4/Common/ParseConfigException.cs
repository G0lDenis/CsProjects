using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common;

public class ParseConfigException : FileSystemException
{
    public ParseConfigException()
        : base("Unable to parse config file")
    {
    }

    public ParseConfigException(string? message)
        : base(message)
    {
    }

    public ParseConfigException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}