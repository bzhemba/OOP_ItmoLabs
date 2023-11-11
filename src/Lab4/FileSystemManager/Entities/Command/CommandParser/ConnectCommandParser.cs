using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Exceptions.ConnectionExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class ConnectCommandParser : AbstractParser
{
    public override object? Parse(string command)
    {
        if (command == null)
        {
            throw new ArgumentException("Command can't be null");
        }

        if (!command.Contains("connect", StringComparison.Ordinal))
            throw new ConnectionException("You are not connected to any file system");
        string[] parts = command.Split(' ');
        if (parts.Length < 4 || parts[0] != "connect")
        {
            throw new ArgumentException("Invalid command format");
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