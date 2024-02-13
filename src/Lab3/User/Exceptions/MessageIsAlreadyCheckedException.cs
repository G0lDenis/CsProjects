namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MessageIsAlreadyCheckedException : UserException
{
    public MessageIsAlreadyCheckedException(string message)
        : base(message)
    {
    }

    public MessageIsAlreadyCheckedException()
    : base("User has already checked this message")
    {
    }

    public MessageIsAlreadyCheckedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}