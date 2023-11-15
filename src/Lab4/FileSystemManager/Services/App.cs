using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.FileTreeVisualizerDecorator;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

public class App
{
    private OperatingSystemContext? _operatingSystem;
    public void LaunchApp()
    {
        var fileTreeVisualizer = new FileTreeVisualizer(new ConsoleWriter());
        var parametrizedFileTreeVisualizer = new DirectorySymbolDecorator(
            "\ud83d\udcc2",
            new FileSymbolDecorator(
                "+",
                new IndentSymbolDecorator(
                    "    ",
                    new DirectoryIndentSymbolDecorator(
                        "│   ",
                        new FileIndentSymbolDecorator(
                            "├── ",
                            new LastIndentSymbolDecorator("└── "))))));
        _operatingSystem = new OperatingSystemContext(
            new PathValidator(),
            parametrizedFileTreeVisualizer.GetTreeWithParametrizedSymbols(fileTreeVisualizer) ?? throw new ArgumentException());
        var connectCommandParser = new ConnectLocalCommandParser();
        var disconnectCommandParser = new DisconnectCommandParser();
        var fileCopyCommandParser = new FileCopyCommandParser();
        var fileDeleteCommandParser = new FileDeleteCommandParser();
        var fileMoveCommandParser = new FileMoveCommandParser();
        var fileRenameCommandParser = new FileRenameCommandParser();
        var fileShowCommandParser = new FileShowConsoleCommandParser();
        var treeGoToCommandParser = new TreeGoToCommandParser();
        var treeListCommandParser = new TreeListCommandParser();
        connectCommandParser.SetNext(disconnectCommandParser)
            ?.SetNext(fileCopyCommandParser)
            ?.SetNext(fileDeleteCommandParser)
            ?.SetNext(fileMoveCommandParser)
            ?.SetNext(fileCopyCommandParser)
            ?.SetNext(fileRenameCommandParser)
            ?.SetNext(fileShowCommandParser)
            ?.SetNext(treeGoToCommandParser)
            ?.SetNext(treeListCommandParser);
        ICommand? request = null;
        do
        {
            string? command = Console.ReadLine();
            if (command != null) request = connectCommandParser.Parse(command);
            request?.Execute(_operatingSystem);
        }
        while (request is not DisconnectCommand);
    }

    public void CloseApp()
    {
        _operatingSystem?.Disconnect();
    }
}