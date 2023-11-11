using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class TreeListCommandParser : AbstractParser
{
    public override object? Parse(string command)
    {
        if (command == null)
        {
            throw new ArgumentException("Command can't be null");
        }

        if (!command.Contains("tree list", StringComparison.Ordinal))
            return base.Parse(command);
        string[] parts = command.Split(' ');
        if (parts.Length < 2 || parts[0] != "tree" || parts[1] != "list")
        {
            throw new ArgumentException("Invalid command format");
        }

        int depth = 0;
        for (int i = 2; i < parts.Length; i++)
        {
            if (parts[i] != "-d" || i + 1 >= parts.Length) continue;
            if (int.TryParse(parts[i + 1], out depth))
            {
                i++;
            }
        }

        ICommand treeListCommand = new TreeListCommand(depth);
        return treeListCommand;
    }
}