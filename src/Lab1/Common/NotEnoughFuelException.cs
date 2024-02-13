namespace Itmo.ObjectOrientedProgramming.Lab1.Common;

public sealed class NotEnoughFuelException : ShipException
{
    public NotEnoughFuelException()
        : base("Remaining fuel is less than we need")
    {
    }

    public NotEnoughFuelException(string message)
        : base(message)
    {
    }

    public NotEnoughFuelException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}