using Itmo.ObjectOrientedProgramming.Lab4.Common;
using Itmo.ObjectOrientedProgramming.Lab4.ParserStates;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopyCommand : ICommand
{
    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public string SourcePath { get; }
    public string DestinationPath { get; }

    public CommandExecuteAnswer Execute(IProgamState state)
    {
        try
        {
            state.CopyFile(SourcePath, DestinationPath);

            return new CommandExecuteAnswer(state, CommandExecuteResults.Success);
        }
        catch (FileSystemException)
        {
            return new CommandExecuteAnswer(state, CommandExecuteResults.Fail);
        }
    }
}