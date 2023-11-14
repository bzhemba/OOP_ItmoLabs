using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

internal class Program
{
    public static void Main()
    {
        // var printer = new DirectoryTreePrinter();
        // printer.PrintDirectoryTree("/Users/mariabazenova/RiderProjects/bzhemba/src/Lab1/SpaceTravel/Entities/Environments/");
        // string? startDir = "/Users/mariabazenova/RiderProjects/bzhemba/src/Lab1/";
        var consoleWriter = new ConsoleWriter();
        new FileTreeVisualizer(consoleWriter)
        {
        }.Print();
    }
}