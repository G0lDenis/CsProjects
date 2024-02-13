using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;

public class FileCopyOption : ParserOption
{
    public override ICommand ParseOption(string[] args)
    {
        if (args.Length != 4 || args[0] != "file" || args[1] != "copy")
            return base.ParseOption(args);

        return new FileCopyCommand(args[2], args[3]);
    }
}