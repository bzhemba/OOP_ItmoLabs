namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class FileCopyCommand : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute(OperatingSystemContext operatingSystemContext)
    {
        operatingSystemContext?.CopyFile(_sourcePath, _destinationPath);
    }
}