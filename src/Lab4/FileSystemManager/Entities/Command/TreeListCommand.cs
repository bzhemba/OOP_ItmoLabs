namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class TreeListCommand : ICommand
{
    private int _depth;

    public TreeListCommand(int depth)
    {
        if (depth > 0)
        {
            _depth = depth;
        }
    }

    public void Execute(OperatingSystemContext operatingSystemContext)
    {
        operatingSystemContext?.ShowTreeList(_depth);
    }
}