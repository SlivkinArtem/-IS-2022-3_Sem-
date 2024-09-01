﻿using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class DeleteCommandHandler : CommandHadler
{
    private readonly IFileSystem? _fileSystem;

    public DeleteCommandHandler(IFileSystem? fileSystem)
    {
        _fileSystem = fileSystem;
    }
    public override bool Handle(string? command, string?[] arguments)
    {
        if (command == "Delete")
        {
            ArgumentNullException.ThrowIfNull(arguments);
            _fileSystem?.DeleteFile(arguments[0]);
            return true;
        }
        return NextHandler?.Handle(command, arguments) ?? false;
    }
}