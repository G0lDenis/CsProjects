using Itmo.ObjectOrientedProgramming.Lab4.Common;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.ParserStates;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    public ConnectCommand(string address, FileSystemModes fileSystemMode)
    {
        Address = address;
        FileSystemMode = fileSystemMode;
    }

    public string Address { get; }
    public FileSystemModes FileSystemMode { get; }

    public CommandExecuteAnswer Execute(IProgamState state)
    {
        try
        {
            IFileSystem system = FileSystemMode switch
            {
                FileSystemModes.Local =>
                    new LocalFileSystem(Address),
                _ => throw new FileSystemException(),
            };

            return new CommandExecuteAnswer(
                state.MoveToConnected(system),
                CommandExecuteResults.Success);
        }
        catch (FileSystemException)
        {
            return new CommandExecuteAnswer(state, CommandExecuteResults.Fail);
        }
    }
}