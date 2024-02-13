using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;

public class FileDeleteOption : ParserOption
{
    public override ICommand ParseOption(string[] args)
    {
        if (args.Length != 3 || args[0] != "file" || args[1] != "delete")
            return base.ParseOption(args);

        return new FileDeleteCommand(args[2]);
    }
}