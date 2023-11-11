using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class FileCopyCommandParser : AbstractParser
{
    public override object? Parse(string command)
    {
        if (command == null)
        {
            throw new ArgumentException("Command can't be null");
        }

        if (!command.Contains("file copy", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 4 || parts[0] != "file" || parts[1] != "copy")
        {
            throw new ArgumentException("Invalid command format");
        }

        string sourcePath = parts[2];
        string destinationPath = parts[3];
        ICommand fileCopyCommand = new FileCopyCommand(sourcePath, destinationPath);
        return fileCopyCommand;
    }
}