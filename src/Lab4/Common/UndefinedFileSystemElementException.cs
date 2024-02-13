namespace Itmo.ObjectOrientedProgramming.Lab4.Common;

public class UndefinedFileSystemElementException : FileSystemException
{
    public UndefinedFileSystemElementException()
    : base("Undefined file system element got")
    {
    }

    public UndefinedFileSystemElementException(string message)
        : base(message)
    {
    }

    public UndefinedFileSystemElementException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}