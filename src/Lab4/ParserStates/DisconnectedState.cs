using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Common;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserStates;

public class DisconnectedState : IProgamState
{
    public IProgamState MoveToConnected(IFileSystem fileSystem)
    {
        return new ConnectedState(fileSystem);
    }

    public IProgamState MoveToDisconnected()
    {
        return new DisconnectedState();
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        throw new ConnectionException();
    }

    public void DeleteFile(string path)
    {
        throw new ConnectionException();
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        throw new ConnectionException();
    }

    public StreamReader ShowFile(string path)
    {
        throw new ConnectionException();
    }

    public void RenameFile(string path, string name)
    {
        throw new ConnectionException();
    }

    public void TreeGoto(string path)
    {
        throw new ConnectionException();
    }

    public DirectoriesExplorer.DirectoriesExplorer TreeList()
    {
        throw new ConnectionException();
    }
}