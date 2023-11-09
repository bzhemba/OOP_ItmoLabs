using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

public class DirectoryHandler : Handler
{
    public override void HandleRequest(string path, int level)
    {
        if (Directory.Exists(path))
        {
            Console.WriteLine($"{new string('-', level)} Directory: {Path.GetFileName(path)}");
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            foreach (string directory in directories)
            {
                NextHandler?.HandleRequest(directory, level + 1);
            }

            foreach (string file in files)
            {
                Console.WriteLine($"{new string('-', level + 1)} File: {Path.GetFileName(file)}");
            }
        }
        else
        {
            NextHandler?.HandleRequest(path, level);
        }
    }
}