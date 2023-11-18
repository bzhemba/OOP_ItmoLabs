using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class TreeListCommandParser : AbstractParser
{
    public override ICommand? Parse(string command)
    {
        if (command == null)
        {
            Writer.Write(new CommandFormatNotification().Notification);
            return null;
        }

        if (!command.Contains("tree list", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 2 || parts[0] != "tree" || parts[1] != "list")
        {
            Writer.Write(new CommandFormatNotification().Notification);
            return null;
        }

        int depth = 1;
        for (int i = 2; i < parts.Length; i++)
        {
            if (parts[i] != "-d" || i + 1 >= parts.Length) continue;
            if (int.TryParse(parts[i + 1], out depth))
            {
                i++;
            }
        }

        ICommand treeListCommand = new TreeListCommand(depth);
        return treeListCommand;
    }
}