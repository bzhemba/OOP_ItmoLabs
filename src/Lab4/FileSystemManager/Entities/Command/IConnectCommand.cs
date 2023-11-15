namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public interface IConnectCommand : ICommand
{
    new void Execute(OperatingSystemContext operatingSystemContext);
}