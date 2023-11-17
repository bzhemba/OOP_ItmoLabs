using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class FileShowConsoleCommandParser : AbstractParser
{
    public override ICommand? Parse(string command)
    {
        if (command == null)
        {
            Writer.Write(new CommandFormatNotification().Notification);
            return null;
        }

        if (!command.Contains("file show", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 5 || parts[0] != "file" || parts[1] != "show")
        {
            Writer.Write(new CommandFormatNotification().Notification);
            return null;
        }

        string path = parts[2];
        string mode = "console";
        for (int i = 3; i < parts.Length; i++)
        {
            if (parts[i] != "-m")
            {
                mode = parts[i + 1];
            }
        }

        if (mode != "console") return base.Parse(command);
        ICommand fileShowCommand = new FileShowConsoleCommand(path);
        return fileShowCommand;
    }
}