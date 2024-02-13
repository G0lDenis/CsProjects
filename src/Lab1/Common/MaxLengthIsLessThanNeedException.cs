namespace Itmo.ObjectOrientedProgramming.Lab1.Common;

public class MaxLengthIsLessThanNeedException : ShipException
{
    public MaxLengthIsLessThanNeedException()
        : base("Max length is less than we need to get through")
    {
    }

    public MaxLengthIsLessThanNeedException(string message)
        : base(message)
    {
    }

    public MaxLengthIsLessThanNeedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}