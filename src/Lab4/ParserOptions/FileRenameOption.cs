using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;

public class FileRenameOption : ParserOption
{
    public override ICommand ParseOption(string[] args)
    {
        if (args.Length != 4 || args[0] != "file" || args[1] != "rename")
            return base.ParseOption(args);

        return new FileRenameCommand(args[2], args[3]);
    }
}