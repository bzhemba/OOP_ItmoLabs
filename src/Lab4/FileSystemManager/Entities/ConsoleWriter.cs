using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.Symbols;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

public class ConsoleWriter : IWriter
{
    private Symbol _symbol;
    public ConsoleWriter(Symbol symbol)
    {
        _symbol = symbol;
    }

    public void WriteWithSymbol(FileSystemInfo file)
    {
        if (file == null) return;
        Console.Write(GetSymbol(file));
        Console.Write(file.Name);
    }

    public void WriteLine()
    {
        Write(" " + Environment.NewLine);
    }

    public string GetSymbol(FileSystemInfo file)
    {
        return file.IsDirectory() ? _symbol.DirectorySymbol : _symbol.FileSymbol;
    }

    public void Write(string text)
    {
        Console.Write(text);
    }

    public void WriteIndent(string prefix)
    {
        Console.Write(prefix + _symbol.FileIndentSymbol);
    }

    public void WriteLastIndent(string prefix)
    {
        Console.Write(prefix + _symbol.LastIndentSymbol);
    }

    public void WriteFirstIndent(string prefix)
    {
        Console.Write(prefix + _symbol.DirectoryIndentSymbol);
    }
}