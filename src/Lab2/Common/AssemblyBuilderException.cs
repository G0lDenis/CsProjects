namespace Itmo.ObjectOrientedProgramming.Lab2.Common;

public class AssemblyBuilderException : AssemblyException
{
    public AssemblyBuilderException(string message)
        : base(message)
    {
    }

    public AssemblyBuilderException()
        : base("Assembly builder exception")
    {
    }

    public AssemblyBuilderException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}