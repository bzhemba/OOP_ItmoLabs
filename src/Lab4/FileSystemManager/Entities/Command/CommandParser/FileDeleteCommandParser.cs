using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class FileDeleteCommandParser : AbstractParser
{
    public override ICommand? Parse(string command)
    {
        if (command == null)
        {
            Console.WriteLine(new CommandFormatNotification().Notification);
            return null;
        }

        if (!command.Contains("file delete", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 3 || parts[0] != "file" || parts[1] != "delete")
        {
            Console.WriteLine(new CommandFormatNotification().Notification);
            return null;
        }

        string path = parts[2];
        ICommand fileDeleteCommand = new FileDeleteCommand(path);
        return fileDeleteCommand;
    }
}