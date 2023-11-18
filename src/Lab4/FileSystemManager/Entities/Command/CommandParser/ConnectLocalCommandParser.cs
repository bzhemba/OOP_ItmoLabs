using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class ConnectLocalCommandParser : AbstractParser
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
            Writer.Write(new ConnectionNotification().Notification);
            return null;
        }

        string[] parts = command.Split(' ');
        if (parts.Length < 4 || parts[0] != "connect" || parts[2] != "-m")
        {
            Writer.Write(new CommandFormatNotification().Notification);
        }

        string address = parts[1];
        string? mode = parts[3];

        if (mode != "local") return base.Parse(command);
        var connectCommand = new ConnectToLocalSystemCommand(address);
        return connectCommand;
    }
}