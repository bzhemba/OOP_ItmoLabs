namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class FileDeleteCommand : ICommand
{
    private string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public void Execute(OperatingSystemContext operatingSystemContext)
    {
        operatingSystemContext?.DeleteFile(_path);
    }
}