using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

public static class FileSystemInfoExtensions
{
    public static bool IsDirectory(this FileSystemInfo fsItem)
    {
        return fsItem != null && (fsItem.Attributes & FileAttributes.Directory) == FileAttributes.Directory;
    }
}