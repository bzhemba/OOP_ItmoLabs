namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models;

public interface IPathValidator
{
    bool IsPathAbsolute(string path);
}