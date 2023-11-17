using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

public class ConsoleWriter : IWriter
{
    public void WriteNewLine()
    {
        Write(Environment.NewLine);
    }

    public void Write(string text)
    {
        Console.Write(text);
    }
}