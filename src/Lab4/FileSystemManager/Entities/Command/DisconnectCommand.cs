using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class DisconnectCommand : ICommand
{
    public void Execute(IFileSystem fileSystem)
    {
        fileSystem?.Disconnect();
    }
}