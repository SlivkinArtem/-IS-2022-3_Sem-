using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class ConnectCommandHandler : CommandHadler
{
    private readonly IFileSystem? _fileSystem;

    public ConnectCommandHandler(IFileSystem? fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override bool Handle(string? command, string?[] arguments)
    {
        Console.WriteLine($"Handling command '{command}' in ConnectCommandHandler");
        if (command == "Connect")
        {
            ArgumentNullException.ThrowIfNull(arguments);
            string? address = arguments[0];
            string? modeString = arguments[1];
            if (Enum.TryParse(modeString, true, out FileSystemMode mode))
            {
                var connectCommand = new ConnectCommand(_fileSystem, address, mode);
                connectCommand.Execute();
            }
            else
            {
                Console.WriteLine($"Invalid file system mode: {modeString}");
            }
            return true;
        }
        return NextHandler?.Handle(command, arguments) ?? false;    
    }
}
