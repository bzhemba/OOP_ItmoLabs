namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.Symbols;

public class Symbol
{
    public string FileSymbol { get; } = "▪";
    public string DirectorySymbol { get; } = "\ud83d\udcc2";
    public string LastIndentSymbol { get; } = "└── ";
    public string FileIndentSymbol { get; } = "├── ";
    public string DirectoryIndentSymbol { get; } = "│   ";
    public string IndentSymbol { get; } = "    ";
}