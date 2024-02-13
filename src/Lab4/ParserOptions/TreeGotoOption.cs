using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;

public class TreeGotoOption : ParserOption
{
    public override ICommand ParseOption(string[] args)
    {
        if (args.Length < 3 || args[0] != "tree" || args[1] != "goto")
            return base.ParseOption(args);

        return new TreeGotoCommand(args[2]);
    }
}