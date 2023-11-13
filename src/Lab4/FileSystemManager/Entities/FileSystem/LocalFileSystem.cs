using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.FileSystem;

public class LocalFileSystem : IFileSystem
{
    private string? _absolutePath;
    private IPathValidator _pathValidator;
    private FileTextVisualizer _fileTextVisualizer;
    private FileTreeVisualizer _fileTreeVisualizer;
    public LocalFileSystem(IPathValidator pathValidator, FileTextVisualizer fileTextVisualizer, FileTreeVisualizer fileTreeVisualizer)
    {
        _pathValidator = pathValidator;
        _fileTextVisualizer = fileTextVisualizer;
        _fileTreeVisualizer = fileTreeVisualizer;
    }

    public void Connect(string address)
    {
        if (!_pathValidator.IsPathAbsolute(address))
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
        if (!Path.Exists(path)) return;
        if (_pathValidator.IsPathAbsolute(path))
        {
            _fileTreeVisualizer.SetStartDirectory(path);
        }
        else
        {
            if (_absolutePath == null) return;
            string fullPath;
            fullPath = _pathValidator.CreateAbsolutePath(_absolutePath, path);
            _fileTreeVisualizer.SetStartDirectory(fullPath);
        }
    }

    public void ShowTreeList(int depth)
    {
        _fileTreeVisualizer.Print(depth);
    }

    public void ShowContent(string path, string mode)
    {
        if (_absolutePath == null) return;
        string fullPath = _pathValidator.CreateAbsolutePath(_absolutePath, path);
        _fileTextVisualizer.Print(fullPath);
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
        string oldPath = _pathValidator.CreateAbsolutePath(_absolutePath, sourcePath);
        string newPath = _pathValidator.CreateAbsolutePath(_absolutePath, destinationPath);
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
        string fullPath = _pathValidator.CreateAbsolutePath(_absolutePath, path);
        File.Delete(fullPath);
    }

    public void RenameFile(string path, string name)
    {
        if (_absolutePath == null || path == null) return;
        string oldPath = _pathValidator.CreateAbsolutePath(_absolutePath, path);
        string newPath = _pathValidator.CreateAbsolutePath(_absolutePath, name);

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
}