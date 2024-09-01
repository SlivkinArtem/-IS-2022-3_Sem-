using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class CopyCommandHandler : CommandHadler
{
    private readonly IFileSystem? _fileSystem;

    public CopyCommandHandler(IFileSystem? fileSystem)
    {
        _fileSystem = fileSystem;
    }
    public override bool Handle(string? command, string?[] arguments)
    {
        if (command == "Copy")
        {
            ArgumentNullException.ThrowIfNull(arguments);
            _fileSystem?.CopyFile(arguments[0], arguments[1]);
            return true;
        }
        return NextHandler?.Handle(command, arguments) ?? false;
    }
}