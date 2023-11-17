using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

public class FileСontentVisualizer
{
    private IWriter _writer;

    public FileСontentVisualizer(IWriter writer)
    {
        _writer = writer;
    }

    public void Print(string path)
    {
        using (var sr = new StreamReader(path))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                _writer.Write(File.ReadAllText(path));
            }
        }

        _writer.WriteNewLine();
    }
}