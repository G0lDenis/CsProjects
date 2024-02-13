using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserStates;

public interface IProgamState
{
    IProgamState MoveToConnected(IFileSystem fileSystem);

    IProgamState MoveToDisconnected();

    void CopyFile(string sourcePath, string destinationPath);

    void DeleteFile(string path);

    void MoveFile(string sourcePath, string destinationPath);

    StreamReader ShowFile(string path);

    void RenameFile(string path, string name);

    void TreeGoto(string path);

    DirectoriesExplorer.DirectoriesExplorer TreeList();
}