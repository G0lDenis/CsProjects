using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;

public class TreeListOption : ParserOption
{
    private readonly Writers.Writers _writer;

    public TreeListOption(Writers.Writers writer)
    {
        _writer = writer;
    }

    public override ICommand ParseOption(string[] args)
    {
        if (args.Length < 2 || args[0] != "tree" || args[1] != "list")
            return base.ParseOption(args);

        int depth = -1;
        string? path = null;

        if (args.Length % 2 != 0 || args.Length > 6)
            return base.ParseOption(args);

        for (int i = 0; i < (args.Length - 2) / 2; i++)
        {
            if (args[2 + (i * 2)] == "-d")
                depth = int.Parse(args[3 + (i * 2)], CultureInfo.CurrentCulture);
            else if (args[2 + (i * 2)] == "-c")
                path = args[3 + (i * 2)];
        }

        return new TreeListCommand(_writer, path, depth);
    }
}