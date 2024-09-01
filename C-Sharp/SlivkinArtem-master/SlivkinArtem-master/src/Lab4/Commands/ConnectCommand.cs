using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private readonly IFileSystem _fileSystem;
    private readonly string _address;
    private readonly FileSystemMode _mode;

    public ConnectCommand(IFileSystem? fileSystem, string? address, FileSystemMode mode)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        _address = address ?? throw new ArgumentNullException(nameof(address));
        _mode = mode;
    }

    public void Execute()
    {
        _fileSystem.Connect(_address, _mode);
    }
}