using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class FileRenameCommandParser : AbstractParser
{
    public override object? Parse(string command)
    {
        if (command == null)
        {
            return new CommandFormatNotification().Notification;
        }

        if (!command.Contains("file rename", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 4 || parts[0] != "file" || parts[1] != "rename")
        {
            return new CommandFormatNotification().Notification;
        }

        string path = parts[2];
        string name = parts[3];
        ICommand fileRenameCommand = new FileRenameCommand(path, name);
        return fileRenameCommand;
    }
}