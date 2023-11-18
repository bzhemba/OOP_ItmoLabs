namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public interface ICommand
{
    void Execute(OperatingSystemContext operatingSystemContext);
}