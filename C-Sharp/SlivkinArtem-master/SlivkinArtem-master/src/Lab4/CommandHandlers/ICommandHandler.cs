namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public interface ICommandHandler
{
    ICommandHandler SetNext(ICommandHandler nextHandler);
    bool Handle(string? command, string?[] arguments);
}