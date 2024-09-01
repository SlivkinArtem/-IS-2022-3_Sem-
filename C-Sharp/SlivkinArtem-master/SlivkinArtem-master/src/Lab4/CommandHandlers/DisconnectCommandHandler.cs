using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class DisconnectCommandHandler : CommandHadler
{
    private readonly IFileSystem? _fileSystem;

    public DisconnectCommandHandler(IFileSystem? fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override bool Handle(string? command, string?[] arguments)
    {
        if (command == "Disconnect")
        {
            ArgumentNullException.ThrowIfNull(arguments);
            var disconnectCommand = new DisconnectCommand(_fileSystem);
            disconnectCommand.Execute();
            return true;
        }
        return NextHandler?.Handle(command, arguments) ?? false;
    }
}