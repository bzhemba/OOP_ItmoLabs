using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class ConnectCommandParser : AbstractParser
{
    public override ICommand? Parse(string command)
    {
        if (command == null)
        {
            Console.WriteLine(new CommandFormatNotification().Notification);
            return null;
        }

        if (!command.Contains("connect", StringComparison.Ordinal))
        {
            Console.WriteLine(new ConnectionNotification().Notification);
            return null;
        }

        string[] parts = command.Split(' ');
        if (parts.Length < 4 || parts[0] != "connect")
        {
            Console.WriteLine(new CommandFormatNotification().Notification);
        }

        string address = parts[1];
        string mode = string.Empty;
        for (int i = 2; i < parts.Length; i++)
        {
            if (parts[i] != "-m" || i + 1 >= parts.Length) continue;
            mode = parts[i];
        }

        ICommand connectCommand = new ConnectCommand(address, mode);
        return connectCommand;
    }
}