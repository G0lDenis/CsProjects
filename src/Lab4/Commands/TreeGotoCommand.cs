using Itmo.ObjectOrientedProgramming.Lab4.Common;
using Itmo.ObjectOrientedProgramming.Lab4.ParserStates;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGotoCommand : ICommand
{
    public TreeGotoCommand(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public CommandExecuteAnswer Execute(IProgamState state)
    {
        try
        {
            state.TreeGoto(Path);

            return new CommandExecuteAnswer(state, CommandExecuteResults.Success);
        }
        catch (FileSystemException)
        {
            return new CommandExecuteAnswer(state, CommandExecuteResults.Fail);
        }
    }
}