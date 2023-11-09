using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

public class FileHandler : Handler
{
    public override void HandleRequest(string path, int level)
    {
        if (File.Exists(path))
        {
            Console.WriteLine($"{new string('-', level)} File: {Path.GetFileName(path)}");
        }
        else
        {
            NextHandler?.HandleRequest(path, level);
        }
    }
}