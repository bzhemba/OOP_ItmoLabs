namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;

public abstract class AbstractParser : ICommandParser
{
    private ICommandParser? _nextParser;
    protected IWriter Writer { get; private set; } = new ConsoleWriter();

    public ICommandParser? SetNext(ICommandParser? nextHandler)
    {
        _nextParser = nextHandler;
        return nextHandler;
    }

    public virtual ICommand? Parse(string command)
    {
        return _nextParser?.Parse(command);
    }

    public void SetErrorWriter(IWriter writer)
    {
        Writer = writer;
    }
}