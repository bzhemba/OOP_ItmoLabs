using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        _writer.WriteNewLine();
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

    private static bool IsDirectory(string path)
    {
        return Directory.Exists(path);
    }

    private static List<FileSystemInfo> GetSortedFileInfos(DirectoryInfo di)
    {
        var fsItems = di.GetFileSystemInfos().ToList();
        fsItems.Sort((f1, f2) => string.Compare(f1.Name, f2.Name, StringComparison.Ordinal));
        return fsItems;
    }

    private void PrintTree(string startDirectory, int maxDepth, string prefix = "", int depth = 0)
    {
        if (depth >= maxDepth)
        {
            return;
        }

        var di = new DirectoryInfo(startDirectory);
        List<FileSystemInfo> fsItems = GetSortedFileInfos(di);

        PrintChildrenFiles(fsItems, prefix, maxDepth, depth);
    }

    private void PrintChildrenFiles(List<FileSystemInfo> fsItems, string prefix, int maxDepth, int depth)
    {
        foreach (FileSystemInfo fsItem in fsItems.Take(fsItems.Count - 1))
        {
            _writer.Write(prefix + FileIndentSymbol);
            _writer.Write(GetSymbol(fsItem.FullName) + fsItem.Name);
            _writer.WriteNewLine();
            if (IsDirectory(fsItem.FullName))
            {
                PrintTree(fsItem.FullName, maxDepth, prefix + DirectoryIndentSymbol, depth + 1);
            }
        }

        FileSystemInfo? lastFsItem = fsItems.LastOrDefault();
        if (lastFsItem == null) return;
        _writer.Write(prefix + LastIndentSymbol);
        _writer.Write(GetSymbol(lastFsItem.FullName) + lastFsItem.Name);
        _writer.WriteNewLine();
        if (IsDirectory(lastFsItem.FullName))
        {
            PrintTree(lastFsItem.FullName, maxDepth, prefix + IndentSymbol, depth + 1);
        }
    }

    private string GetSymbol(string path)
    {
        return IsDirectory(path) ? DirectorySymbol : FileSymbol;
    }
}