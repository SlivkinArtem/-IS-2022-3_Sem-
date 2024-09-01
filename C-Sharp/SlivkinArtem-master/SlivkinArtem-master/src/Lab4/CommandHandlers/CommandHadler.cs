using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public abstract class CommandHadler : ICommandHandler
{
    protected ICommandHandler? NextHandler { get; private set; }

    public ICommandHandler SetNext(ICommandHandler nextHandler)
    {
        NextHandler = nextHandler ?? throw new ArgumentNullException(nameof(nextHandler));
        return NextHandler;
    }

    public abstract bool Handle(string? command, string?[] arguments);
}