namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class DisconnectCommand : ICommand
{
    public void Execute(OperatingSystemContext operatingSystemContext)
    {
        operatingSystemContext?.Disconnect();
    }
}