namespace Lab5.Application.CommandsHandling;

public interface ICommandHandler
{
    ICommandHandler SetNext(ICommandHandler nextHandler);
    bool Handle(string? command);
}