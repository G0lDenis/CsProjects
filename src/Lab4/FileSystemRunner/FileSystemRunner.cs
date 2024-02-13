using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ParserStates;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemRunner;

public class FileSystemRunner
{
    private readonly IParser _parser;
    private readonly IWriter _writer;
    private IProgamState _state = new DisconnectedState();

    public FileSystemRunner(IParser parser, IWriter writer)
    {
        _parser = parser;
        _writer = writer;
        Running = true;
    }

    public bool Running { get; private set; }

    public void Parse()
    {
        if (Running)
        {
            ICommand? command = _parser.ParseLine();
            _writer.Clear();
            if (command is null || command is EmptyCommand)
            {
                _writer.WriteLine("Unexpected command got\n");
            }
            else
            {
                CommandExecuteAnswer answer = command.Execute(_state);
                switch (answer.Result)
                {
                    case CommandExecuteResults.Fail:
                        _writer.WriteLine("Unable to execute command\n");
                        break;
                    case CommandExecuteResults.Success:
                        _state = answer.State;
                        break;
                }
            }
        }
    }
}