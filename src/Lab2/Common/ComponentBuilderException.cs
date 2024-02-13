namespace Itmo.ObjectOrientedProgramming.Lab2.Common;

public class ComponentBuilderException : AssemblyException
{
    public ComponentBuilderException(string message)
        : base(message)
    {
    }

    public ComponentBuilderException()
        : base("Component builder exception")
    {
    }

    public ComponentBuilderException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}