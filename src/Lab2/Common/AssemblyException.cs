using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Common;

public class AssemblyException : Exception
{
    public AssemblyException(string message)
        : base(message)
    {
    }

    public AssemblyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public AssemblyException()
        : base("Assembly exception")
    {
    }
}