using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

public interface IWriter
{
    void Write(string text);
    void WriteLine();
    string GetSymbol(FileSystemInfo file);
    void WriteWithSymbol(FileSystemInfo file);
    public void WriteLastIndent(string prefix);
    public void WriteFirstIndent(string prefix);
    public void WriteIndent(string prefix);
}