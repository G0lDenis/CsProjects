using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;

public abstract class ParserOption : IParserOption
{
    private IParserOption? _nextOption;

    public IParserOption SetNextOption(IParserOption parserOption)
    {
        _nextOption = parserOption;

        return parserOption;
    }

    public virtual ICommand ParseOption(string[] args)
    {
        if (_nextOption is null)
            return new EmptyCommand();

        return _nextOption.ParseOption(args);
    }
}