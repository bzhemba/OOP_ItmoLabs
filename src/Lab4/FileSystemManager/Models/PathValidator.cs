using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models;

public class PathValidator : IPathValidator
{
    public bool IsPathAbsolute(string path)
    {
        return Path.IsPathRooted(path);
    }

    public string CreateAbsolutePath(string path1, string path2)
    {
        if (path2 == null || path1 == null) return "One part of path is missing";
        string fName = path2.Substring(path1.Length + 1);
        return Path.Combine(path1, fName);
    }
}