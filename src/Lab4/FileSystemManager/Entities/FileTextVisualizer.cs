using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

public class FileTextVisualizer
{
    private IWriter _writer;

    public FileTextVisualizer(IWriter writer)
    {
        _writer = writer;
    }

    public void Print(string path)
    {
        _writer.Write(File.ReadAllText(path));
        _writer.WriteLine();
    }
}