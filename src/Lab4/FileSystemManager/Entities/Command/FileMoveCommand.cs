using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class FileMoveCommand : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute(IFileSystem fileSystem)
    {
        fileSystem?.MoveFile(_sourcePath, _destinationPath);
    }
}