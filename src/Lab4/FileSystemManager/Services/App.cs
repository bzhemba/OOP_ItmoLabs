using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

public class App
{
    public string FileSymbol { get; } = "▪";
    public string DirectorySymbol { get; } = "\ud83d\udcc2";
    public string LastIndentSymbol { get; } = "└── ";
    public string FileIndentSymbol { get; } = "├── ";
    public string DirectoryIndentSymbol { get; } = "│   ";
    public string IndentSymbol { get; } = "    ";

    public static void LaunchApp()
    {
        var operatingSystem = new OperatingSystemContext(new PathValidator(), new FileTreeVisualizer(new ConsoleWriter()));
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
            request?.Execute(operatingSystem);
        }
        while (request is not DisconnectCommand);
    }
}