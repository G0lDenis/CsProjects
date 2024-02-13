using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Common;
using Itmo.ObjectOrientedProgramming.Lab4.ParserStates;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    public FileShowCommand(string path, Writers.Writers writer)
    {
        Path = path;
        Writer = writer switch
        {
            Writers.Writers.ConsoleWriter => new ConsoleWriter(),
            _ => throw new UndefinedWriterException(),
        };
    }

    public string Path { get; }
    public IWriter Writer { get; }

    public CommandExecuteAnswer Execute(IProgamState state)
    {
        try
        {
            StreamReader reader = state.ShowFile(Path);

            string? line = reader.ReadLine();
            while (line != null)
            {
                Writer.WriteLine(line + '\n');
                line = reader.ReadLine();
            }

            reader.Close();

            return new CommandExecuteAnswer(state, CommandExecuteResults.Success);
        }
        catch (FileSystemException)
        {
            return new CommandExecuteAnswer(state, CommandExecuteResults.Fail);
        }
    }
}