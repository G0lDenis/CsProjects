using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class UserException : Exception
{
    public UserException(string message)
        : base(message)
    {
    }

    public UserException()
        : base("User exception")
    {
    }

    public UserException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}