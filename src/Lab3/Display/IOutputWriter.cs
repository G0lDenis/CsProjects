namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public interface IOutputWriter
{
    void WriteText(string text);

    void ClearOutput();
}