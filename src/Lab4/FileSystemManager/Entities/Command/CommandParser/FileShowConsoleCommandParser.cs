using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class FileShowConsoleCommandParser : AbstractParser
{
    public override ICommand? Parse(string command)
    {
        if (command == null)
        {
            Console.WriteLine(new CommandFormatNotification().Notification);
            return null;
        }

        if (!command.Contains("file show", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 5 || parts[0] != "file" || parts[1] != "show")
        {
            Console.WriteLine(new CommandFormatNotification().Notification);
            return null;
        }

        string path = parts[2];
        string mode = string.Empty;
        for (int i = 3; i < parts.Length; i++)
        {
            if (parts[i] != "-m" || i + 1 >= parts.Length) continue;
            mode = parts[i];
        }

        if (mode != "console") return base.Parse(command);
        ICommand fileShowCommand = new FileShowConsoleCommand(path);
        return fileShowCommand;
    }
}