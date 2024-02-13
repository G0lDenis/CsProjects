using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Common;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;

public class FileShowOption : ParserOption
{
    public override ICommand ParseOption(string[] args)
    {
        if (args.Length < 3 || args[0] != "file" || args[1] != "show")
            return base.ParseOption(args);

        if (args.Length == 3)
            return new FileShowCommand(args[2], Writers.Writers.ConsoleWriter);

        if (args[3] == "-m" && args.Length == 5)
        {
            Writers.Writers mode = args[4] switch
            {
                "console" => Writers.Writers.ConsoleWriter,
                _ => throw new UndefinedWriterException(),
            };

            return new FileShowCommand(args[2], mode);
        }

        return base.ParseOption(args);
    }
}