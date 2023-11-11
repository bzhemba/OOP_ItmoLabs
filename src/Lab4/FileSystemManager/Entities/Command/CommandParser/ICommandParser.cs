namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public interface ICommandParser
{
    ICommandParser? SetNext(ICommandParser? nextHandler);
    object? Parse(string command);
}