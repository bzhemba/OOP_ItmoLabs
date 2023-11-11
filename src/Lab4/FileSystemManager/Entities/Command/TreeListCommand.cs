using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class TreeListCommand : ICommand
{
    private int _depth;

    public TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public void Execute(IFileSystem fileSystem)
    {
        fileSystem?.ShowTreeList(_depth);
    }
}