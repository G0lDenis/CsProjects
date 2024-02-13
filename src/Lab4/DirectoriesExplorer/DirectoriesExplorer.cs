using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.DirectoriesExplorer;

public class DirectoriesExplorer
{
    private readonly IFileSystem _fileSystem;
    private readonly string _path;

    public DirectoriesExplorer(IFileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem;
        _path = path;
    }

    public IEnumerable<Tuple<int, string, FileSystemElements>> GetList(int maxDepth)
    {
        return GetList(_path, 0, maxDepth);
    }

    private IEnumerable<Tuple<int, string, FileSystemElements>> GetList(string path, int depth, int maxDepth)
    {
        var container = new List<Tuple<int, string, FileSystemElements>>();

        if (depth > maxDepth && maxDepth != -1)
            return container;

        foreach (string directory in _fileSystem.GetDirectories(path))
        {
            container.Add(new Tuple<int, string, FileSystemElements>(
                depth,
                directory,
                FileSystemElements.Directory));
            container = new List<Tuple<int, string, FileSystemElements>>(
                container.Concat(GetList(Path.Combine(path, directory), depth + 1, maxDepth)));
        }

        foreach (string file in _fileSystem.GetFiles(path))
        {
            container.Add(new Tuple<int, string, FileSystemElements>(
                depth,
                file,
                FileSystemElements.File));
        }

        return container;
    }
}