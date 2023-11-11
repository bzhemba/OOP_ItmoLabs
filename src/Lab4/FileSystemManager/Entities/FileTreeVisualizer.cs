using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.Symbols;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

public class FileTreeVisualizer
{
    private IWriter _writer;
    private Symbol _symbol;
    private string? _startPath;
    public FileTreeVisualizer(Symbol symbol, IWriter writer)
    {
        _symbol = symbol;
        _writer = writer;
    }

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
                _writer.Write(prefix + _symbol.FileIndentSymbol);
                _writer.Write(GetSymbol(fsItem) + fsItem.Name);
                _writer.WriteLine();
                if (fsItem.IsDirectory())
                {
                    PrintTree(fsItem.FullName, maxDepth, prefix + _symbol.DirectoryIndentSymbol, depth + 1);
                }
            }

            FileSystemInfo? lastFsItem = fsItems.LastOrDefault();
            if (lastFsItem == null) return;
            _writer.Write(prefix + _symbol.LastIndentSymbol);
            _writer.Write(GetSymbol(lastFsItem) + lastFsItem.Name);
            _writer.WriteLine();
            if (lastFsItem.IsDirectory())
            {
                PrintTree(lastFsItem.FullName, maxDepth, prefix + _symbol.IndentSymbol, depth + 1);
            }
        }

    private string GetSymbol(FileSystemInfo file)
    {
        return file.IsDirectory() ? _symbol.DirectorySymbol : _symbol.FileSymbol;
    }
}