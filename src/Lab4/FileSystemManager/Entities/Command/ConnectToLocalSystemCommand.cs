using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.FileSystem;
namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class ConnectToLocalSystemCommand : IConnectCommand
{
    private string _address;

    public ConnectToLocalSystemCommand(string address)
    {
        _address = address;
    }

    public void Execute(OperatingSystemContext operatingSystemContext)
    {
        operatingSystemContext?.TransitionToFileSystem(new LocalFileSystem(operatingSystemContext));
        operatingSystemContext?.Connect(_address);
    }
}