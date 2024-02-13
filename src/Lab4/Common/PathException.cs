using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common;

public class PathException : FileSystemException
{
    public PathException()
        : base("Path exception")
    {
    }

    public PathException(string? message)
        : base(message)
    {
    }

    public PathException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}