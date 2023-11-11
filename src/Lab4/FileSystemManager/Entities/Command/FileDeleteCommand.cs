using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class FileDeleteCommand : ICommand
{
    private string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public void Execute(IFileSystem fileSystem)
    {
        fileSystem?.DeleteFile(_path);
    }
}