using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common;

public class UndefinedWriterException : FileSystemException
{
    public UndefinedWriterException()
        : base("Undefined writer got")
    {
    }

    public UndefinedWriterException(string? message)
        : base(message)
    {
    }

    public UndefinedWriterException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}