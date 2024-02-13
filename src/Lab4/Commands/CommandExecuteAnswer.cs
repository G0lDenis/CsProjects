using Itmo.ObjectOrientedProgramming.Lab4.ParserStates;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record CommandExecuteAnswer(IProgamState State, CommandExecuteResults Result);