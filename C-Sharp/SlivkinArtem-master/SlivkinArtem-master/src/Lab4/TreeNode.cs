using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class TreeNode
{
    public TreeNode(string name, bool isDirectory)
    {
        Children = new List<TreeNode>();
        Name = name;
        IsDirectory = isDirectory;
    }

    public string Name { get; private set; }
    public bool IsDirectory { get; private set; }
    public ICollection<TreeNode> Children { get; }

    public static TreeNode CreateFile(string name)
    {
        return new TreeNode(name, false);
    }

    public static TreeNode CreateDirectory(string name)
    {
        return new TreeNode(name, true);
    }

    public void AddDirectory(TreeNode child)
    {
        Children.Add(child);
    }

    public void AddFile(string name, bool isDirectory)
    {
        var child = new TreeNode(name, isDirectory);
        Children.Add(child);
    }
}