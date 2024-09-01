using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class CommandProcessor
{
    private readonly ICommandHandler _commandHandler;

    public CommandProcessor(ICommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
    }
    
    public void Run()
    {
        bool hasNextAction = true;
        while (hasNextAction)
        {
            try
            {
                hasNextAction = ProcessAction();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Error while processing user action\n{e.Message}");
            }
        }
    }
    
    public bool ProcessAction()
    {
        string? command = Console.ReadLine();
        if (string.IsNullOrEmpty(command))
        {
            throw new ArgumentNullException();
        }
        string?[]? splittedCommandParts = command.Split(' ');

        string? commandName = splittedCommandParts?[0];
        ArgumentNullException.ThrowIfNull(splittedCommandParts);
        string?[] arguments = splittedCommandParts.Skip(1).ToArray();
        if (string.Equals(commandName, "Finish", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }
        return _commandHandler.Handle(commandName, arguments);
    }
}