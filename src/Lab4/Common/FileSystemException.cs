using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Common;

public class FileSystemException : Exception
{
    public FileSystemException()
        : base("File system exception")
    {
    }

    public FileSystemException(string? message)
        : base(message)
    {
    }

    public FileSystemException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}