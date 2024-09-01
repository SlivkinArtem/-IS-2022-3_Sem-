using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var fileSystem = new FileSystem();
        var connectHandler = new ConnectCommandHandler(fileSystem);
        var disconnectHandler = new DisconnectCommandHandler(fileSystem);
        
        connectHandler.SetNext(disconnectHandler)
            .SetNext(new MoveCommandHandler(fileSystem))
            .SetNext(new CopyCommandHandler(fileSystem))
            .SetNext(new DeleteCommandHandler(fileSystem))
            .SetNext(new RenameCommandHandler(fileSystem));
        
        var commandProcessor = new CommandProcessor(connectHandler);
        commandProcessor.Run();
    }
}