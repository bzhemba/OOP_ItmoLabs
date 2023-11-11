using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class FileShowCommandParser : AbstractParser
{
    public override object? Parse(string command)
    {
        if (command == null)
        {
            throw new ArgumentException("Command can't be null");
        }

        if (!command.Contains("file show", StringComparison.Ordinal))
            return base.Parse(command ?? string.Empty);
        string[] parts = command.Split(' ');
        if (parts.Length < 5 || parts[0] != "file" || parts[1] != "show")
        {
            throw new ArgumentException("Invalid command format");
        }

        string path = parts[2];
        string mode = string.Empty;
        for (int i = 3; i < parts.Length; i++)
        {
            if (parts[i] != "-m" || i + 1 >= parts.Length) continue;
            mode = parts[i];
        }

        ICommand fileShowCommand = new FileShowCommand(path, mode);
        return fileShowCommand;
    }
}