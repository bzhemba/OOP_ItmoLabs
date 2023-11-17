using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class TreeGoToCommandParser : AbstractParser
{
    public override ICommand? Parse(string command)
    {
        if (command == null)
        {
            Writer.Write(new CommandFormatNotification().Notification);
            return null;
        }

        if (!command.Contains("tree goto", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 3 || parts[0] != "tree" || parts[1] != "goto")
        {
            Writer.Write(new CommandFormatNotification().Notification);
            return null;
        }

        string path = parts[2];
        ICommand treeGoToCommand = new TreeGoToCommand(path);
        return treeGoToCommand;
    }
}