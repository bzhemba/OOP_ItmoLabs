namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models;

public class Symbols
{
    public Symbols(
        string fileSymbol = "▪",
        string directorySymbol = "\ud83d\udcc2",
        string lastIndentSymbol = "└── ",
        string fileIndentSymbol = "├── ",
        string directoryIndentSymbol = "│   ",
        string indentSymbol = "    ")
    {
        FileSymbol = fileSymbol;
        DirectorySymbol = directorySymbol;
        LastIndentSymbol = lastIndentSymbol;
        FileIndentSymbol = fileIndentSymbol;
        DirectoryIndentSymbol = directoryIndentSymbol;
        IndentSymbol = indentSymbol;
    }

    public string FileSymbol { get; private set; }
    public string DirectorySymbol { get; private set; }
    public string LastIndentSymbol { get; private set; }
    public string FileIndentSymbol { get; private set; }
    public string DirectoryIndentSymbol { get; private set; }
    public string IndentSymbol { get; private set; }
}
