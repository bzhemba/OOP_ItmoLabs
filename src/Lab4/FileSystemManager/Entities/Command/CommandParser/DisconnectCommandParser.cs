using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class DisconnectCommandParser : AbstractParser
{
    public override ICommand? Parse(string command)
    {
        if (command == null)
        {
            Console.WriteLine(new CommandFormatNotification().Notification);
            return null;
        }

        if (!command.Contains("disconnect", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length > 1 || parts[0] != "disconnect")
        {
            Console.WriteLine(new CommandFormatNotification().Notification);
            return null;
        }

        ICommand disconnectCommand = new DisconnectCommand();
        return disconnectCommand;
    }
}