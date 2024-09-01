using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class MoveCommandHandler : CommandHadler
{
    private readonly IFileSystem? _fileSystem;

    public MoveCommandHandler(IFileSystem? fileSystem)
    {
        _fileSystem = fileSystem;
    }
    public override bool Handle(string? command, string?[] arguments)
    {
        if (command == "Move")
        {
            ArgumentNullException.ThrowIfNull(arguments);
            _fileSystem?.MoveFile(arguments[0], arguments[1]);
            return true;
        }
        return NextHandler?.Handle(command, arguments) ?? false;
    }
}