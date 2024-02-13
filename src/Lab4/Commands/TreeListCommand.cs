using System;
using System.IO;
using System.Security;
using System.Text.Json;
using Itmo.ObjectOrientedProgramming.Lab4.Common;
using Itmo.ObjectOrientedProgramming.Lab4.DirectoriesExplorer;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.ParserStates;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    public TreeListCommand(Writers.Writers writer, string? configPath, int maxDepth)
    {
        MaxDepth = maxDepth;
        ConfigPath = configPath;
        Writer = writer switch
        {
            Writers.Writers.ConsoleWriter => new ConsoleWriter(),
            _ => throw new UndefinedWriterException(),
        };
    }

    public IWriter Writer { get; }
    public string? ConfigPath { get; }
    public int MaxDepth { get; }

    public CommandExecuteAnswer Execute(IProgamState state)
    {
        try
        {
            TreeListConfig config = ReadConfig(ConfigPath) ?? throw new ParseConfigException();
            DirectoriesExplorer.DirectoriesExplorer explorer = state.TreeList();

            foreach (Tuple<int, string, FileSystemElements> element in explorer.GetList(MaxDepth))
            {
                string indent = new string(config.IndentCharacter, element.Item1);
                string elementName = element.Item2;
                char elementIcon = element.Item3 switch
                {
                    FileSystemElements.Directory => config.DirectoryCharacter,
                    FileSystemElements.File => config.FileCharacter,
                    _ => throw new UndefinedFileSystemElementException(),
                };

                Writer.WriteLine($"{indent}{elementIcon} {elementName}\n");
            }

            return new CommandExecuteAnswer(state, CommandExecuteResults.Success);
        }
        catch (FileSystemException)
        {
            return new CommandExecuteAnswer(state, CommandExecuteResults.Fail);
        }
    }

    private static TreeListConfig? ReadConfig(string? pathToConfig)
    {
        if (pathToConfig is null)
            return new TreeListConfig('-', '-', ' ');

        if (!File.Exists(pathToConfig))
            throw new PathException("Path to config was not found");
        try
        {
            StringTreeListConfig? person = JsonSerializer.Deserialize<StringTreeListConfig>(File.ReadAllText(pathToConfig));

            return new TreeListConfig(person?.FileCharacter[0] ?? '-', person?.DirectoryCharacter[0] ?? '-', person?.IndentCharacter[0] ?? ' ');
        }
        catch (ArgumentNullException)
        {
            return null;
        }
        catch (IOException)
        {
            return null;
        }
        catch (SecurityException)
        {
            return null;
        }
    }

    private record StringTreeListConfig(string FileCharacter, string DirectoryCharacter, string IndentCharacter);
}