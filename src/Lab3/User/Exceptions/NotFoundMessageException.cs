using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class NotFoundMessageException : UserException
{
    public NotFoundMessageException(string message)
        : base(message)
    {
    }

    public NotFoundMessageException()
        : base("Message not found for current user")
    {
    }

    public NotFoundMessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}