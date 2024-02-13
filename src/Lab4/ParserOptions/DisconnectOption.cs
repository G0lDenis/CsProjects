using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;

public class DisconnectOption : ParserOption
{
    public override ICommand ParseOption(string[] args)
    {
        if (args.Length == 0 || args[0] != "disconnect" || args.Length > 1)
            return base.ParseOption(args);

        return new DisconnectCommand();
    }
}