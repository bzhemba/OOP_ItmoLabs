using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

public class FileTreeVisualizer
{
    private IWriter _writer;
    private string? _startPath;
    public FileTreeVisualizer(IWriter writer)
    {
        _writer = writer;
    }

    public string FileSymbol { get; private set; } = "▪";
    public string DirectorySymbol { get; private set; } = "\ud83d\udcc2";
    public string LastIndentSymbol { get; private set; } = "└── ";
    public string FileIndentSymbol { get; private set; } = "├── ";
    public string DirectoryIndentSymbol { get; private set; } = "│   ";
    public string IndentSymbol { get; private set; } = "    ";

    public void Print(int maxDepth = 1)
    {
        if (_startPath == null) return;
        _writer.Write(_startPath);
        _writer.WriteLine();
        PrintTree(_startPath, maxDepth);
    }

    public void SetStartDirectory(string path)
    {
        _startPath = path;
    }

    public FileTreeVisualizer SetDirectorySymbol(string symbol)
    {
        DirectorySymbol = symbol;
        return this;
    }

    public FileTreeVisualizer SetIndentSymbol(string symbol)
    {
        IndentSymbol = symbol;
        return this;
    }

    public FileTreeVisualizer SetFileIndentSymbol(string symbol)
    {
        FileIndentSymbol = symbol;
        return this;
    }

    public FileTreeVisualizer? SetDirectoryIndentSymbol(string symbol)
    {
        DirectoryIndentSymbol = symbol;
        return this;
    }

    public FileTreeVisualizer SetLastIndentSymbol(string symbol)
    {
        LastIndentSymbol = symbol;
        return this;
    }

    public FileTreeVisualizer SetFileSymbol(string symbol)
    {
        FileSymbol = symbol;
        return this;
    }

    private void PrintTree(string startDirectory, int maxDepth, string prefix = "", int depth = 0)
    {
        if (depth >= maxDepth)
        {
            return;
        }

        var di = new DirectoryInfo(startDirectory);
        var fsItems = di.GetFileSystemInfos().ToList();

        fsItems.Sort((f1, f2) => string.Compare(f1.Name, f2.Name, StringComparison.Ordinal));

        foreach (FileSystemInfo fsItem in fsItems.Take(fsItems.Count - 1))
        {
            _writer.Write(prefix + FileIndentSymbol);
            _writer.Write(GetSymbol(fsItem) + fsItem.Name);
            _writer.WriteLine();
            if (fsItem.IsDirectory())
            {
                PrintTree(fsItem.FullName, maxDepth, prefix + DirectoryIndentSymbol, depth + 1);
            }
        }

        FileSystemInfo? lastFsItem = fsItems.LastOrDefault();
        if (lastFsItem == null) return;
        _writer.Write(prefix + LastIndentSymbol);
        _writer.Write(GetSymbol(lastFsItem) + lastFsItem.Name);
        _writer.WriteLine();
        if (lastFsItem.IsDirectory())
        {
            PrintTree(lastFsItem.FullName, maxDepth, prefix + IndentSymbol, depth + 1);
        }
    }

    private string GetSymbol(FileSystemInfo file)
    {
        return file.IsDirectory() ? DirectorySymbol : FileSymbol;
    }
}