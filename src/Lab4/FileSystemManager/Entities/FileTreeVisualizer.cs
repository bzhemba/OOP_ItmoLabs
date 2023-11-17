using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

public class FileTreeVisualizer
{
    private IWriter _writer;
    private string? _startPath;
    private Symbols _symbols;
    public FileTreeVisualizer(IWriter writer, Symbols symbols)
    {
        _writer = writer;
        _symbols = symbols;
    }

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
            _writer.Write(prefix + _symbols.FileIndentSymbol);
            _writer.Write(GetSymbol(fsItem.FullName) + fsItem.Name);
            _writer.WriteNewLine();
            if (IsDirectory(fsItem.FullName))
            {
                PrintTree(fsItem.FullName, maxDepth, prefix + _symbols.DirectoryIndentSymbol, depth + 1);
            }
        }

        FileSystemInfo? lastFsItem = fsItems.LastOrDefault();
        if (lastFsItem == null) return;
        _writer.Write(prefix + _symbols.LastIndentSymbol);
        _writer.Write(GetSymbol(lastFsItem.FullName) + lastFsItem.Name);
        _writer.WriteNewLine();
        if (IsDirectory(lastFsItem.FullName))
        {
            PrintTree(lastFsItem.FullName, maxDepth, prefix + _symbols.IndentSymbol, depth + 1);
        }
    }

    private string GetSymbol(string path)
    {
        return IsDirectory(path) ? _symbols.DirectorySymbol : _symbols.FileSymbol;
    }
}