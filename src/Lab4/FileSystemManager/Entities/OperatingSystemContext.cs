using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

public class OperatingSystemContext
{
    private IFileSystem? _fileSystem;

    public OperatingSystemContext(IPathValidator pathValidator, FileTreeVisualizer fileTreeVisualizer)
    {
        PathValidator = pathValidator;
        TreeVisualizer = fileTreeVisualizer;
    }

    public FileTextVisualizer? TextVisualizer { get; private set; }
    public FileTreeVisualizer TreeVisualizer { get; }

    public IPathValidator PathValidator { get; }
    public void TransitionToFileSystem(IFileSystem? fileSystem)
    {
        this._fileSystem = fileSystem;
        this._fileSystem?.SetOperatingSystemContext(this);
    }

    public void TransitionToTextVisualizer(FileTextVisualizer visualizer)
    {
        this.TextVisualizer = visualizer;
    }

    public void Connect(string address)
    {
        this._fileSystem?.Connect(address);
    }

    public void Disconnect()
    {
        this._fileSystem?.Disconnect();
    }

    public void TreeGoTo(string path)
    {
        this._fileSystem?.TreeGoTo(path);
    }

    public void ShowTreeList(int depth)
    {
        _fileSystem?.ShowTreeList(depth);
    }

    public void ShowContent(string path)
    {
        _fileSystem?.ShowContent(path);
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        _fileSystem?.MoveFile(sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        _fileSystem?.CopyFile(sourcePath, destinationPath);
    }

    public void DeleteFile(string path)
    {
        _fileSystem?.DeleteFile(path);
    }

    public void RenameFile(string path, string name)
    {
        _fileSystem?.RenameFile(path, name);
    }
}