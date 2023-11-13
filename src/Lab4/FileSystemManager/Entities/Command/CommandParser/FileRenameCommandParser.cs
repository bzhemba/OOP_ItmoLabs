using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class FileRenameCommandParser : AbstractParser
{
    public override ICommand? Parse(string command)
    {
        if (command == null)
        {
            Console.WriteLine(new CommandFormatNotification().Notification);
            return null;
        }

        if (!command.Contains("file rename", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 4 || parts[0] != "file" || parts[1] != "rename")
        {
            Console.WriteLine(new CommandFormatNotification().Notification);
            return null;
        }

        string path = parts[2];
        string name = parts[3];
        ICommand fileRenameCommand = new FileRenameCommand(path, name);
        return fileRenameCommand;
    }
}