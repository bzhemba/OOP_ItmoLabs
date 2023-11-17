using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models;

public class PathValidator : IPathValidator
{
    public bool IsPathAbsolute(string path)
    {
        return Path.IsPathRooted(path);
    }
}