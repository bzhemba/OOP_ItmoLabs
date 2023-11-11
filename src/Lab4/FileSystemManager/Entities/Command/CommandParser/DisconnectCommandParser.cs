using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class DisconnectCommandParser : AbstractParser
{
    public override object? Parse(string command)
    {
        if (command == null)
        {
            throw new ArgumentException("Command can't be null");
        }

        if (!command.Contains("disconnect", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length > 1 || parts[0] != "disconnect")
        {
            throw new ArgumentException("Invalid command format");
        }

        ICommand disconnectCommand = new DisconnectCommand();
        return disconnectCommand;
    }
}