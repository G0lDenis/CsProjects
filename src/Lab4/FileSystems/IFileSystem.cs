using System.Collections.Generic;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    void CopyFile(string sourcePath, string destinationPath);

    void DeleteFile(string path);

    void MoveFile(string sourcePath, string destinationPath);

    StreamReader ShowFile(string path);

    void RenameFile(string path, string name);

    void TreeGoto(string path);

    DirectoriesExplorer.DirectoriesExplorer TreeList();

    IEnumerable<string> GetDirectories(string path);

    IEnumerable<string> GetFiles(string path);
}