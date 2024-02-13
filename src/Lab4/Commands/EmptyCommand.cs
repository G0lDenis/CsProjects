using Itmo.ObjectOrientedProgramming.Lab4.ParserStates;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class EmptyCommand : ICommand
{
    public CommandExecuteAnswer Execute(IProgamState state)
    {
        return new CommandExecuteAnswer(state, CommandExecuteResults.Fail);
    }
}