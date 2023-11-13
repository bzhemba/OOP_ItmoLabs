using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

public class App
{

    public void LaunchApp()
    {
        var connectCommandParser = new ConnectCommandParser();
        var disconnectCommandParser = new DisconnectCommandParser();
        var fileCopyCommandParser = new FileCopyCommandParser();
        var fileDeleteCommandParser = new FileDeleteCommandParser();
        var fileMoveCommandParser = new FileMoveCommandParser();
        var fileRenameCommandParser = new FileRenameCommandParser();
        var fileShowCommandParser = new FileShowCommandParser();
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
        object request = null;
        do
        {
            string? command = Console.ReadLine();
            if (command != null) request = connectCommandParser.Parse(command);
            
        }
        while (request is not DisconnectCommand);
    }
}