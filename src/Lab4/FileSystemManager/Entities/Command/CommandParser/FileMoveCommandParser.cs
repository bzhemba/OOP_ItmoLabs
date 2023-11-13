using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class FileMoveCommandParser : AbstractParser
{
    public override object? Parse(string command)
    {
        if (command == null)
        {
            return new CommandFormatNotification().Notification;
        }

        if (!command.Contains("file move", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 4 || parts[0] != "file" || parts[1] != "move")
        {
            return new CommandFormatNotification().Notification;
        }

        string sourcePath = parts[2];
        string destinationPath = parts[3];
        ICommand fileMoveCommand = new FileMoveCommand(sourcePath, destinationPath);
        return fileMoveCommand;
    }
}