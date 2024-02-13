using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;
using Itmo.ObjectOrientedProgramming.Lab4.Readers;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var parser = new FileSystemParser(new ConsoleReader());
        parser
            .SetNextOption(new ConnectOption())
            .SetNextOption(new DisconnectOption())
            .SetNextOption(new FileCopyOption())
            .SetNextOption(new FileDeleteOption())
            .SetNextOption(new FileMoveOption())
            .SetNextOption(new FileRenameOption())
            .SetNextOption(new FileShowOption())
            .SetNextOption(new TreeGotoOption())
            .SetNextOption(new TreeListOption(Writers.Writers.ConsoleWriter));

        var runner = new FileSystemRunner.FileSystemRunner(parser, new ConsoleWriter());

        while (runner.Running)
        {
            runner.Parse();
        }
    }
}