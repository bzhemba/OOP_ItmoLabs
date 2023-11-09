using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.Symbols;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

public class FileTree
{
    private IWriter _writer;
    private Symbol _symbol;
    private string _startPath;
    private int _maxDepth;
    public FileTree(Symbol symbol, IWriter writer, string startPath, int maxDepth)
    {
        _symbol = symbol;
        _writer = writer;
        _startPath = startPath;
        _maxDepth = maxDepth;
    }

    public void Print()
        {
            _writer.Write(_startPath);
            _writer.WriteLine();
            PrintTree(_startPath);
        }

    private void PrintTree(string startDir, string prefix = "", int depth = 0)
        {
            if (depth >= _maxDepth)
            {
                return;
            }

            var di = new DirectoryInfo(startDir);
            var fsItems = di.GetFileSystemInfos().ToList();

            fsItems.Sort((f1, f2) => string.Compare(f1.Name, f2.Name, StringComparison.Ordinal));

            foreach (FileSystemInfo fsItem in fsItems.Take(fsItems.Count - 1))
            {
                _writer.WriteIndent(prefix);
                _writer.WriteWithSymbol(fsItem);
                _writer.WriteLine();
                if (fsItem.IsDirectory())
                {
                    PrintTree(fsItem.FullName,  prefix + _symbol.DirectoryIndentSymbol, depth + 1);
                }
            }

            FileSystemInfo? lastFsItem = fsItems.LastOrDefault();
            if (lastFsItem == null) return;
            _writer.WriteLastIndent(prefix);
            _writer.WriteWithSymbol(lastFsItem);
            _writer.WriteLine();
            if (lastFsItem.IsDirectory())
            {
                PrintTree(lastFsItem.FullName, prefix + _symbol.IndentSymbol, depth + 1);
            }
        }
}