using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;

public interface IParserOption
{
    ICommand ParseOption(string[] args);

    IParserOption SetNextOption(IParserOption parserOption);
}