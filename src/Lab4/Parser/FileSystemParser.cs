using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;
using Itmo.ObjectOrientedProgramming.Lab4.Readers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class FileSystemParser : IParser
{
    private readonly IReader _reader;
    private IParserOption _startOption = new EmptyOption();

    public FileSystemParser(IReader reader)
    {
        _reader = reader;
    }

    public IParserOption SetNextOption(IParserOption option)
    {
        _startOption = option;

        return option;
    }

    public ICommand? ParseLine()
    {
        string? read = _reader.ReadLine();
        if (read is not null)
            return _startOption.ParseOption(read.Split());

        return null;
    }
}