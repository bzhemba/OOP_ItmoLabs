using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class TreeGoToCommandParser : AbstractParser
{
    public override object? Parse(string command)
    {
        if (command == null)
        {
            throw new ArgumentException("Command can't be null");
        }

        if (!command.Contains("tree goto", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 3 || parts[0] != "tree" || parts[1] != "goto")
        {
            throw new ArgumentException("Invalid command format");
        }

        string path = parts[2];
        ICommand treeGoToCommand = new TreeGoToCommand(path);
        return treeGoToCommand;
    }
}