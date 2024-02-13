using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;

public class EmptyOption : ParserOption
{
    public override ICommand ParseOption(string[] args)
    {
        return new EmptyCommand();
    }
}