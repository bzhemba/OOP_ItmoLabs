using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.FileSystem;

public class LocalFileSystem : IFileSystem
{
    private OperatingSystemContext? _operatingSystem;
    private string? _absolutePath;

    public LocalFileSystem(OperatingSystemContext? operatingSystem)
    {
        _operatingSystem = operatingSystem;
    }

    public void Connect(string address)
    {
        if (_operatingSystem != null && !_operatingSystem.PathValidator.IsPathAbsolute(address))
        {
            Console.WriteLine("You can't connect using this path");
            return;
        }

        _absolutePath = address;
    }

    public void Disconnect()
    {
        _absolutePath = null;
    }

    public void TreeGoTo(string path)
    {
        if (_operatingSystem == null) return;
        if (_operatingSystem.PathValidator.IsPathAbsolute(path))
        {
            _operatingSystem.TreeVisualizer.SetStartDirectory(path);
        }
        else
        {
            if (_absolutePath == null) return;
            string fullPath;
            fullPath = CreateAbsolutePath(_absolutePath, path);
            if (!Path.Exists(fullPath)) return;
            _operatingSystem.TreeVisualizer.SetStartDirectory(fullPath);
        }
    }

    public void ShowTreeList(int depth)
    {
        _operatingSystem?.TreeVisualizer.Print(depth);
    }

    public void ShowContent(string path)
    {
        if (_absolutePath == null) return;
        if (_operatingSystem == null) return;
        string fullPath = CreateAbsolutePath(_absolutePath, path);
        _operatingSystem.TextVisualizer?.Print(fullPath);
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("File at the source path not found");
            return;
        }

        if (File.Exists(destinationPath))
        {
            File.Delete(destinationPath);
        }

        File.Move(sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        if (_absolutePath == null || sourcePath == null) return;
        if (_operatingSystem == null) return;
        string oldPath = CreateAbsolutePath(_absolutePath, sourcePath);
        string newPath = CreateAbsolutePath(_absolutePath, destinationPath);
        try
        {
            File.Copy(oldPath, newPath);
        }
        catch (IOException copyError)
        {
            Console.WriteLine(copyError.Message);
        }
    }

    public void DeleteFile(string path)
    {
        if (_absolutePath == null || path == null) return;
        if (_operatingSystem == null) return;
        string fullPath = CreateAbsolutePath(_absolutePath, path);
        File.Delete(fullPath);
    }

    public void RenameFile(string path, string name)
    {
        if (_absolutePath == null || path == null) return;
        if (_operatingSystem == null) return;
        string oldPath = CreateAbsolutePath(_absolutePath, path);
        string newPath = CreateAbsolutePath(_absolutePath, name);

        if (!File.Exists(oldPath))
        {
            using FileStream fs = File.Create(oldPath);
        }

        if (File.Exists(newPath))
        {
            Console.WriteLine("File with this name already exists");
            return;
        }

        File.Move(oldPath, newPath);
    }

    public string CreateAbsolutePath(string path1, string path2)
    {
        return Path.GetFullPath(path2, path1);
    }

    private static bool IsDirectory(string path)
    {
        return Directory.Exists(path);
    }
}