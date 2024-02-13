using Itmo.ObjectOrientedProgramming.Lab4.Common;
using Itmo.ObjectOrientedProgramming.Lab4.ParserStates;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    public FileRenameCommand(string path, string name)
    {
        Path = path;
        Name = name;
    }

    public string Path { get; }
    public string Name { get; }

    public CommandExecuteAnswer Execute(IProgamState state)
    {
        try
        {
            state.RenameFile(Path, Name);

            return new CommandExecuteAnswer(state, CommandExecuteResults.Success);
        }
        catch (FileSystemException)
        {
            return new CommandExecuteAnswer(state, CommandExecuteResults.Fail);
        }
    }
}