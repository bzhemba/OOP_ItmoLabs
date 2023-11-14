namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;

public class FileShowConsoleCommand : ICommand
{
    private string _path;

    public FileShowConsoleCommand(string path)
    {
        _path = path;
    }

    public void Execute(OperatingSystemContext operatingSystemContext)
    {
        operatingSystemContext?.TransitionToTextVisualizer(new FileTextVisualizer(new ConsoleWriter()));
        operatingSystemContext?.ShowContent(_path);
    }
}