using Itmo.ObjectOrientedProgramming.Lab4.ParserStates;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    CommandExecuteAnswer Execute(IProgamState state);
}