using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;

public class FileMoveOption : ParserOption
{
    public override ICommand ParseOption(string[] args)
    {
        if (args.Length != 4 || args[0] != "file" || args[1] != "move")
            return base.ParseOption(args);

        return new FileMoveCommand(args[2], args[3]);
    }
}