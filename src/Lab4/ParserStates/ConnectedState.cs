using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Common;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserStates;

public class ConnectedState : IProgamState
{
    private readonly IFileSystem _fileSystem;

    public ConnectedState(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public IProgamState MoveToConnected(IFileSystem fileSystem)
    {
        throw new ConnectionException("Filesystem is already connected");
    }

    public IProgamState MoveToDisconnected()
    {
        return new DisconnectedState();
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        _fileSystem.CopyFile(sourcePath, destinationPath);
    }

    public void DeleteFile(string path)
    {
        _fileSystem.DeleteFile(path);
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        _fileSystem.MoveFile(sourcePath, destinationPath);
    }

    public StreamReader ShowFile(string path)
    {
        return _fileSystem.ShowFile(path);
    }

    public void RenameFile(string path, string name)
    {
        _fileSystem.RenameFile(path, name);
    }

    public void TreeGoto(string path)
    {
        _fileSystem.TreeGoto(path);
    }

    public DirectoriesExplorer.DirectoriesExplorer TreeList()
    {
        return _fileSystem.TreeList();
    }
}