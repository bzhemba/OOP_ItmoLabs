namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public class AbstractParser : ICommandParser
{
    private ICommandParser? _nextParser;
    public ICommandParser? SetNext(ICommandParser? nextHandler)
    {
        this._nextParser = nextHandler;
        return nextHandler;
    }

    public virtual object? Parse(string command)
    {
        return this._nextParser?.Parse(command);
    }
}