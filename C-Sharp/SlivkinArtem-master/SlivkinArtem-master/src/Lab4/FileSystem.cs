using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class FileSystem : IFileSystem
{
    private string? _currentDirectory;

    public void Connect(string? address, FileSystemMode mode)
    {
        if (mode == FileSystemMode.Local)
        {
            _currentDirectory = address;
            Console.WriteLine($"Connected to local system at {address}");
        }
        else
        {
            Console.WriteLine($"Unsupported system mode: {mode}");
        }
    }

    public void Disconnect() 
    {
        Console.WriteLine("Disconnected from the system");
    }

    public void ShowFileContent(string? path, OutputMode mode)
    {
        ArgumentNullException.ThrowIfNull(path);
        string content = File.ReadAllText(path);
        if (mode == OutputMode.Console)
            Console.WriteLine($"Content of file {path}:\n{content}");
    }

    public void MoveFile(string? sourcePath, string? destinationPath)
    {
        ArgumentNullException.ThrowIfNull(destinationPath);
        ArgumentNullException.ThrowIfNull(sourcePath);
        File.Move(sourcePath, destinationPath);
        Console.WriteLine($"File moved from {sourcePath} to {destinationPath}");
    }

    public void CopyFile(string? sourcePath, string? destinationPath)
    {
        ArgumentNullException.ThrowIfNull(destinationPath);
        ArgumentNullException.ThrowIfNull(sourcePath);
        File.Copy(sourcePath, destinationPath);
        Console.WriteLine($"File copied from {sourcePath} to {destinationPath}");
    }

    public void DeleteFile(string? path)
    {
        ArgumentNullException.ThrowIfNull(path);
        File.Delete(path);
        Console.WriteLine($"File deleted: {path}");
    }

    public void RenameFile(string? path, string? newName)
    {
        if (path == newName) throw SystemException.FileOfTheSameNameException();
        ArgumentNullException.ThrowIfNull(path);
        ArgumentNullException.ThrowIfNull(newName);
        var fileInfo = new FileInfo(path);
        ArgumentNullException.ThrowIfNull(fileInfo.Directory?.FullName);
        string newPath = Path.Combine(fileInfo.Directory.FullName, newName);
        File.Move(path, newPath);
        Console.WriteLine($"File renamed from {path} to {newPath}");
    }
    
    public TreeNode GetFileSystemTree(string? path, int depth)
    {
        ArgumentNullException.ThrowIfNull(path);

        var directoryInfo = new DirectoryInfo(path);

        TreeNode root = BuildTree(directoryInfo, depth);

        string treeString = PrintTree(root, 0);

        Console.WriteLine(treeString);

        return root;
    }
    
    private TreeNode BuildTree(DirectoryInfo directoryInfo, int depth)
    {
        var node = TreeNode.CreateDirectory(directoryInfo.Name);

        if (depth > 0)
        {
            foreach (DirectoryInfo subDirectory in directoryInfo.GetDirectories())
            {
                TreeNode childNode = BuildTree(subDirectory, depth - 1);
                node.AddDirectory(childNode);
            }

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                _ = TreeNode.CreateFile(file.Name);
                node.AddFile(file.Name, false);
            }
        }
        return node;
    }
    private string PrintTree(TreeNode node, int indentLevel)
    {
        string indentation = new string(' ', indentLevel * 2);
        
        string nodeString = $"{indentation}{node.Name} {(node.IsDirectory ? "(Directory)" : string.Empty)}";
        ArgumentNullException.ThrowIfNull(nodeString);

        foreach (TreeNode childNode in node.Children)
        {
            nodeString += Environment.NewLine + PrintTree(childNode, indentLevel + 1);
        }

        return nodeString;
    }
}