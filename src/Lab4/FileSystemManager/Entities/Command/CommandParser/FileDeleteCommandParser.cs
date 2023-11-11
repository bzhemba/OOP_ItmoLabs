using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class FileDeleteCommandParser : AbstractParser
{
    public override object? Parse(string command)
    {
        if (command == null)
        {
            throw new ArgumentException("Command can't be null");
        }

        if (!command.Contains("file delete", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 3 || parts[0] != "file" || parts[1] != "delete")
        {
            throw new ArgumentException("Invalid command format");
        }

        string path = parts[2];
        ICommand fileDeleteCommand = new FileDeleteCommand(path);
        return fileDeleteCommand;
    }
}