using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

public class SymbolicLinkHandler : Handler
{
    public override void HandleRequest(string path, int level)
    {
        if (File.Exists(path) && (File.GetAttributes(path) & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint)
        {
            Console.WriteLine($"{new string('-', level)} Symbolic Link: {Path.GetFileName(path)}");
        }
        else
        {
            NextHandler?.HandleRequest(path, level);
        }
    }
}