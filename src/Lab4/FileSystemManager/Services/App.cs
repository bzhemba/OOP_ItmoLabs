using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

public class App : IDisposable
{
    private OperatingSystemContext? _operatingSystem;
    private bool disposed;
    public void LaunchApp()
    {
        var fileTreeVisualizer = new FileTreeVisualizer(new ConsoleWriter(), new Symbols());
        _operatingSystem = new OperatingSystemContext(
            new PathValidator(), fileTreeVisualizer);
        var connectCommandParser = new ConnectLocalCommandParser();
        var disconnectCommandParser = new DisconnectCommandParser();
        var fileCopyCommandParser = new FileCopyCommandParser();
        var fileDeleteCommandParser = new FileDeleteCommandParser();
        var fileMoveCommandParser = new FileMoveCommandParser();
        var fileRenameCommandParser = new FileRenameCommandParser();
        var fileShowCommandParser = new FileShowConsoleCommandParser();
        var treeGoToCommandParser = new TreeGoToCommandParser();
        var treeListCommandParser = new TreeListCommandParser();
        disconnectCommandParser.SetNext(fileCopyCommandParser)
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
        while (request is not IConnectCommand);
        do
        {
            string? command = Console.ReadLine();
            if (command != null) request = disconnectCommandParser.Parse(command);
            request?.Execute(_operatingSystem);
        }
        while (request is not DisconnectCommand);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing)
        {
            _operatingSystem?.Disconnect();
        }

        disposed = true;
    }
}