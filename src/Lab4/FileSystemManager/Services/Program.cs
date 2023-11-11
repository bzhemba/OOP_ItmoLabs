using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.Symbols;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

internal class Program
{
    public static void Main()
    {
        // var printer = new DirectoryTreePrinter();
        // printer.PrintDirectoryTree("/Users/mariabazenova/RiderProjects/bzhemba/src/Lab1/SpaceTravel/Entities/Environments/");
        string? startDir = "/Users/mariabazenova/RiderProjects/bzhemba/src/Lab1/";
        var symbols = new Symbol();
        var consoleWriter = new ConsoleWriter(symbols);
        new FileTreeVisualizer(symbols, consoleWriter, startDir, 3)
        {
        }.Print();
    }
}