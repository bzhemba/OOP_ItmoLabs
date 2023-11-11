using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.FileSystem;
namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class ConnectCommand : ICommand
{
    private string _address;
    private string _mode;

    public ConnectCommand(string address, string mode)
    {
        _address = address;
        _mode = mode;
    }

    public void Execute(IFileSystem fileSystem)
    {
        fileSystem?.Connect(_address);
    }
}