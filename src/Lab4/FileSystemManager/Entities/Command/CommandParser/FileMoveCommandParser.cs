using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class FileMoveCommandParser : AbstractParser
{
    public override object? Parse(string command)
    {
        if (command == null)
        {
            throw new ArgumentException("Command can't be null");
        }

        if (!command.Contains("file move", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 4 || parts[0] != "file" || parts[1] != "move")
        {
            throw new ArgumentException("Invalid command format");
        }

        string sourcePath = parts[2];
        string destinationPath = parts[3];
        ICommand fileMoveCommand = new FileMoveCommand(sourcePath, destinationPath);
        return fileMoveCommand;
    }
}