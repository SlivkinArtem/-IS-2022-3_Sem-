﻿namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    private readonly IFileSystem? _fileSystem;
    public DisconnectCommand(IFileSystem? fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Execute()
    {
        _fileSystem?.Disconnect();
    }
}