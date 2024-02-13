using Itmo.ObjectOrientedProgramming.Lab4.ParserStates;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    public CommandExecuteAnswer Execute(IProgamState state)
    {
        return new CommandExecuteAnswer(state.MoveToDisconnected(), CommandExecuteResults.Success);
    }
}