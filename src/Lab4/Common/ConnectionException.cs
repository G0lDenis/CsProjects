using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common;

public class ConnectionException : FileSystemException
{
    public ConnectionException()
        : base("Connection exception")
    {
    }

    public ConnectionException(string? message)
        : base(message)
    {
    }

    public ConnectionException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}