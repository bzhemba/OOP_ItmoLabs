using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class FileShowCommand : ICommand
{
    private string _path;
    private string _mode;

    public FileShowCommand(string path, string mode)
    {
        _path = path;
        _mode = mode;
    }

    public void Execute(IFileSystem fileSystem)
    {
        fileSystem?.ShowContent(_path, _mode);
    }
}