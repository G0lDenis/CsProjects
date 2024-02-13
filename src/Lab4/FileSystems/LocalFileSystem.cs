using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using Itmo.ObjectOrientedProgramming.Lab4.Common;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class LocalFileSystem : IFileSystem
{
    private readonly string _basePath;
    private string _path = string.Empty;

    public LocalFileSystem(string basePath)
    {
        if (!Directory.Exists(basePath))
            throw new PathException();
        _basePath = basePath;
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        string? relativeSource = GetRelativePath(sourcePath);
        if (relativeSource is null || !File.Exists(Path.GetFullPath(relativeSource, _basePath)))
            throw new PathException();
        string? relativeDestination = GetRelativePath(destinationPath);

        if (relativeDestination is null || !Directory.Exists(Path.GetFullPath(relativeDestination, _basePath)))
            throw new PathException();

        try
        {
            new FileInfo(Path.GetFullPath(relativeSource, _basePath))
                .CopyTo(Path.Combine(
                    Path.GetFullPath(relativeDestination, _basePath),
                    Path.GetFileName(relativeSource)));
        }
        catch (IOException)
        {
            throw new PathException("File with such name also exists in directory");
        }
        catch (SecurityException)
        {
            throw new PathException("You have no access to this file");
        }
    }

    public void DeleteFile(string path)
    {
        string? relative = GetRelativePath(path);
        if (relative is null || !File.Exists(Path.GetFullPath(relative, _basePath)))
            throw new PathException();
        try
        {
            new FileInfo(Path.GetFullPath(relative, _basePath)).Delete();
        }
        catch (IOException)
        {
            throw new PathException("Error connected with Microsoft os");
        }
        catch (SecurityException)
        {
            throw new PathException("You have no access to this file");
        }
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        string? relativeSource = GetRelativePath(sourcePath);
        if (relativeSource is null || !File.Exists(Path.GetFullPath(relativeSource, _basePath)))
            throw new PathException();
        string? relativeDestination = GetRelativePath(sourcePath);
        if (relativeDestination is null || !Directory.Exists(Path.GetFullPath(relativeDestination, _basePath)))
            throw new PathException();
        try
        {
            new FileInfo(Path.GetFullPath(relativeSource, _basePath))
                .MoveTo(Path.Combine(
                    Path.GetFullPath(relativeDestination, _basePath),
                    Path.GetFileName(relativeSource)));
        }
        catch (IOException)
        {
            throw new PathException("File with such name also exists in directory");
        }
        catch (SecurityException)
        {
            throw new PathException("You have no access to this file");
        }
    }

    public StreamReader ShowFile(string path)
    {
        string? relative = GetRelativePath(path);
        if (relative is null || !File.Exists(Path.GetFullPath(relative, _basePath)))
            throw new PathException();

        return new StreamReader(Path.GetFullPath(relative, _basePath));
    }

    public void RenameFile(string path, string name)
    {
        string? relative = GetRelativePath(path);
        if (relative is null || !File.Exists(Path.GetFullPath(relative, _basePath)))
            throw new PathException();
        try
        {
            string? root = Path.GetDirectoryName(Path.GetFullPath(path, _basePath));
            if (root is null)
            {
                throw new PathException("Unable to get path");
            }

            new FileInfo(Path.GetFullPath(path, _basePath)).MoveTo(Path.Combine(root, name));
        }
        catch (IOException)
        {
            throw new PathException("File with such name also exists in directory");
        }
        catch (SecurityException)
        {
            throw new PathException("You have no access to this file");
        }
    }

    public void TreeGoto(string path)
    {
        string? relative = GetRelativePath(path);
        if (relative is null || !Directory.Exists(Path.GetFullPath(relative, _basePath)))
            throw new PathException();
        _path = relative;
    }

    public DirectoriesExplorer.DirectoriesExplorer TreeList()
    {
        return new DirectoriesExplorer.DirectoriesExplorer(this, Path.GetFullPath(_path, _basePath));
    }

    public IEnumerable<string> GetDirectories(string path)
    {
        try
        {
            var directories = new List<string>();

            foreach (string directoryPath in Directory.GetDirectories(path))
            {
                directories.Add(new DirectoryInfo(directoryPath).Name);
            }

            return directories;
        }
        catch (UnauthorizedAccessException)
        {
            return new List<string>();
        }
    }

    public IEnumerable<string> GetFiles(string path)
    {
        try
        {
            var files = new List<string>();

            foreach (string filePath in Directory.GetFiles(path))
            {
                files.Add(Path.GetFileName(filePath) ?? throw new PathException());
            }

            return files;
        }
        catch (UnauthorizedAccessException)
        {
            return new List<string>();
        }
    }

    private string? GetRelativePath(string path)
    {
        if (Path.Exists(Path.Combine(_basePath, _path, path)))
            return Path.Combine(_path, path);
        if (Path.Exists(Path.Combine(_basePath, path)))
            return path;
        return null;
    }
}