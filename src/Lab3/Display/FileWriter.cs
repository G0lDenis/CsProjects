using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class FileWriter : IOutputWriter
{
    private readonly string _path;

    public FileWriter(string path)
    {
        _path = path;
    }

    public void WriteText(string text)
    {
        File.WriteAllText(_path, text);
    }

    public void ClearOutput()
    {
        File.WriteAllText(_path, string.Empty);
    }
}