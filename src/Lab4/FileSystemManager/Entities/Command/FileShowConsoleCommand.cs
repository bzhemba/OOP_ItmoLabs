namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class FileShowConsoleCommand : IFileShowCommand
{
    private string _path;

    public FileShowConsoleCommand(string path)
    {
        _path = path;
    }

    public void Execute(OperatingSystemContext operatingSystemContext)
    {
        operatingSystemContext?.TransitionToTextVisualizer(new FileСontentVisualizer(new ConsoleWriter()));
        operatingSystemContext?.ShowContent(_path);
    }
}