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

    public void Execute(OperatingSystemContext operatingSystemContext)
    {
        operatingSystemContext?.MoveFile(_sourcePath, _destinationPath);
    }
}