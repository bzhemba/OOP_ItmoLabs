namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.FileSystem;

public interface IFileSystem
{
    void Connect(string address);
    void Disconnect();

    void TreeGoTo(string path);

    void ShowTreeList(int depth);

    void ShowContent(string path, string mode);

    void MoveFile(string sourcePath, string destinationPath);
    void CopyFile(string sourcePath, string destinationPath);

    void DeleteFile(string path);

    void RenameFile(string path, string name);
}