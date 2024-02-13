using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ParserOptions;
using Itmo.ObjectOrientedProgramming.Lab4.Readers;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    [Fact]
    public void ConnectParseWithoutModeShouldReturnConnectCommandTest()
    {
        string source = "/home/bye";
        string stringCommand = $"connect {source}";
        IParser parser = GetParser(stringCommand);

        ICommand? parsedCommand = parser.ParseLine();

        Assert.NotNull(parsedCommand);
        Assert.IsType<ConnectCommand>(parsedCommand);
        Assert.Equal(source, ((ConnectCommand)parsedCommand).Address);
        Assert.Equal(FileSystemModes.Local, ((ConnectCommand)parsedCommand).FileSystemMode);
    }

    [Fact]
    public void ConnectParseWithModeShouldReturnConnectCommandTest()
    {
        string source = "/home/bye";
        string stringCommand = $"connect {source} -m local";
        IParser parser = GetParser(stringCommand);

        ICommand? parsedCommand = parser.ParseLine();

        Assert.NotNull(parsedCommand);
        Assert.IsType<ConnectCommand>(parsedCommand);
        Assert.Equal(source, ((ConnectCommand)parsedCommand).Address);
        Assert.Equal(FileSystemModes.Local, ((ConnectCommand)parsedCommand).FileSystemMode);
    }

    [Fact]
    public void FileCopyParseShouldReturnFileCopyCommandTest()
    {
        string source = "go/a.txt";
        string destination = "go2";
        string stringCommand = $"file copy {source} {destination}";
        IParser parser = GetParser(stringCommand);

        ICommand? parsedCommand = parser.ParseLine();

        Assert.NotNull(parsedCommand);
        Assert.IsType<FileCopyCommand>(parsedCommand);
        Assert.Equal(source, ((FileCopyCommand)parsedCommand).SourcePath);
        Assert.Equal(destination, ((FileCopyCommand)parsedCommand).DestinationPath);
    }

    [Fact]
    public void FileMoveParseShouldReturnFileMoveCommandTest()
    {
        string source = "go/a.txt";
        string destination = "go2";
        string stringCommand = $"file move {source} {destination}";
        IParser parser = GetParser(stringCommand);

        ICommand? parsedCommand = parser.ParseLine();

        Assert.NotNull(parsedCommand);
        Assert.IsType<FileMoveCommand>(parsedCommand);
        Assert.Equal(source, ((FileMoveCommand)parsedCommand).SourcePath);
        Assert.Equal(destination, ((FileMoveCommand)parsedCommand).DestinationPath);
    }

    [Fact]
    public void FileDeleteParseShouldReturnFileDeleteCommandTest()
    {
        string source = "go/a.txt";
        string stringCommand = $"file delete {source}";
        IParser parser = GetParser(stringCommand);

        ICommand? parsedCommand = parser.ParseLine();

        Assert.NotNull(parsedCommand);
        Assert.IsType<FileDeleteCommand>(parsedCommand);
        Assert.Equal(source, ((FileDeleteCommand)parsedCommand).Path);
    }

    [Fact]
    public void FileRenameParseShouldReturnFileRenameCommandTest()
    {
        string source = "go/a.txt";
        string newName = "a4.txt";
        string stringCommand = $"file rename {source} {newName}";
        IParser parser = GetParser(stringCommand);

        ICommand? parsedCommand = parser.ParseLine();

        Assert.NotNull(parsedCommand);
        Assert.IsType<FileRenameCommand>(parsedCommand);
        Assert.Equal(source, ((FileRenameCommand)parsedCommand).Path);
        Assert.Equal(newName, ((FileRenameCommand)parsedCommand).Name);
    }

    [Fact]
    public void FileShowWithoutModeParseShouldReturnFileShowCommandTest()
    {
        string source = "go/a.txt";
        string stringCommand = $"file show {source}";
        IParser parser = GetParser(stringCommand);

        ICommand? parsedCommand = parser.ParseLine();

        Assert.NotNull(parsedCommand);
        Assert.IsType<FileShowCommand>(parsedCommand);
        Assert.Equal(source, ((FileShowCommand)parsedCommand).Path);
        Assert.IsType<ConsoleWriter>(((FileShowCommand)parsedCommand).Writer);
    }

    [Fact]
    public void FileShowWithModeParseShouldReturnFileShowCommandTest()
    {
        string source = "go/a.txt";
        string stringCommand = $"file show {source} -m console";
        IParser parser = GetParser(stringCommand);

        ICommand? parsedCommand = parser.ParseLine();

        Assert.NotNull(parsedCommand);
        Assert.IsType<FileShowCommand>(parsedCommand);
        Assert.Equal(source, ((FileShowCommand)parsedCommand).Path);
        Assert.IsType<ConsoleWriter>(((FileShowCommand)parsedCommand).Writer);
    }

    [Fact]
    public void TreeGotoParseShouldReturnTreeGotoCommandTest()
    {
        string source = "awesomepath/eee";
        string stringCommand = $"tree goto {source}";
        IParser parser = GetParser(stringCommand);

        ICommand? parsedCommand = parser.ParseLine();

        Assert.NotNull(parsedCommand);
        Assert.IsType<TreeGotoCommand>(parsedCommand);
        Assert.Equal(source, ((TreeGotoCommand)parsedCommand).Path);
    }

    [Fact]
    public void TreeListWithoutParametersParseShouldReturnTreeListCommandWithDefaultParametersTest()
    {
        string stringCommand = "tree list";
        IParser parser = GetParser(stringCommand);

        ICommand? parsedCommand = parser.ParseLine();

        Assert.NotNull(parsedCommand);
        Assert.IsType<TreeListCommand>(parsedCommand);
        Assert.Equal(-1, ((TreeListCommand)parsedCommand).MaxDepth);
        Assert.IsType<ConsoleWriter>(((TreeListCommand)parsedCommand).Writer);
        Assert.Null(((TreeListCommand)parsedCommand).ConfigPath);
    }

    [Fact]
    public void TreeListWithParametersPathParseShouldReturnTreeListCommandWithCorrectConfigPathAndDepthTest()
    {
        string configPath = "/config/there";
        int depth = 2;
        string stringCommand = $"tree list -c {configPath} -d {depth}";
        IParser parser = GetParser(stringCommand);

        ICommand? parsedCommand = parser.ParseLine();

        Assert.NotNull(parsedCommand);
        Assert.IsType<TreeListCommand>(parsedCommand);
        Assert.Equal(depth, ((TreeListCommand)parsedCommand).MaxDepth);
        Assert.IsType<ConsoleWriter>(((TreeListCommand)parsedCommand).Writer);
        Assert.NotNull(((TreeListCommand)parsedCommand).ConfigPath);
        Assert.Equal(configPath, ((TreeListCommand)parsedCommand).ConfigPath);
    }

    [Fact]
    public void UndefinedParseShouldReturnEmptyCommandTest()
    {
        string stringCommand = $"makeMeCoffee please";
        IParser parser = GetParser(stringCommand);

        ICommand? parsedCommand = parser.ParseLine();

        Assert.NotNull(parsedCommand);
        Assert.IsType<EmptyCommand>(parsedCommand);
    }

    private static IParser GetParser(string parserReadLine)
    {
        IReader? reader = Substitute.For<IReader>();
        reader.ReadLine().Returns(parserReadLine);

        var parser = new FileSystemParser(reader);
        parser
            .SetNextOption(new ConnectOption())
            .SetNextOption(new DisconnectOption())
            .SetNextOption(new FileCopyOption())
            .SetNextOption(new FileDeleteOption())
            .SetNextOption(new FileMoveOption())
            .SetNextOption(new FileRenameOption())
            .SetNextOption(new FileShowOption())
            .SetNextOption(new TreeGotoOption())
            .SetNextOption(new TreeListOption(Writers.Writers.ConsoleWriter));

        return parser;
    }
}