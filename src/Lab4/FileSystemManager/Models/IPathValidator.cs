namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models;

public interface IPathValidator
{
    bool IsPathAbsolute(string path);
    public string CreateAbsolutePath(string path1, string path2);
}