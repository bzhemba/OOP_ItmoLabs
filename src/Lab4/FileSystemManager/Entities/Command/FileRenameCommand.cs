namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class FileRenameCommand : ICommand
{
    private string _address;
    private string _name;

    public FileRenameCommand(string address, string name)
    {
        _address = address;
        _name = name;
    }

    public void Execute(OperatingSystemContext operatingSystemContext)
    {
        operatingSystemContext?.RenameFile(_address, _name);
    }
}