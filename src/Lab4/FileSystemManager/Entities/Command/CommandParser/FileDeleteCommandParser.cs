using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class FileDeleteCommandParser : AbstractParser
{
    public override object? Parse(string command)
    {
        if (command == null)
        {
            return new CommandFormatNotification().Notification;
        }

        if (!command.Contains("file delete", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 3 || parts[0] != "file" || parts[1] != "delete")
        {
            return new CommandFormatNotification().Notification;
        }

        string path = parts[2];
        ICommand fileDeleteCommand = new FileDeleteCommand(path);
        return fileDeleteCommand;
    }
}