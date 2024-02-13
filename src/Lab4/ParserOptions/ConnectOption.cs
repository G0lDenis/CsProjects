using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Common;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;

public class ConnectOption : ParserOption
{
    public override ICommand ParseOption(string[] args)
    {
        if (args.Length == 0 || args[0] != "connect" || args.Length < 2)
            return base.ParseOption(args);

        if (args[1] != "-m" && args.Length == 2)
            return new ConnectCommand(args[1], FileSystemModes.Local);

        if (args[2] == "-m" && args.Length == 4)
        {
            FileSystemModes mode = args[3] switch
            {
                "local" => FileSystemModes.Local,
                _ => throw new UndefinedFileSystemElementException(),
            };

            return new ConnectCommand(args[1], mode);
        }

        return base.ParseOption(args);
    }
}