namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface IFileSystem
{ 
    void Connect(string? address, FileSystemMode mode);
    void Disconnect();
    TreeNode GetFileSystemTree(string? path, int depth);
    void ShowFileContent(string? path, OutputMode mode);
    void MoveFile(string? sourcePath, string? destinationPath);
    void CopyFile(string? sourcePath, string? destinationPath);
    void DeleteFile(string? path);
    void RenameFile(string? path, string? newName);
}