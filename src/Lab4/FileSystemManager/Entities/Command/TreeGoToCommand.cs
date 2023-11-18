namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class TreeGoToCommand : ICommand
{
    private string _path;

    public TreeGoToCommand(string path)
    {
        _path = path;
    }

    public void Execute(OperatingSystemContext operatingSystemContext)
    {
       operatingSystemContext?.TreeGoTo(_path);
    }
}