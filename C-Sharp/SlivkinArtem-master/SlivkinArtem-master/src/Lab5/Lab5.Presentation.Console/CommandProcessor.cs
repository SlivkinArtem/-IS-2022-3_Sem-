using Lab5.Application.CommandsHandling;

namespace Lab5.Presentation.Console;

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
                System.Console.WriteLine($"Error while processing user action\n{e.Message}");
            }
        }
    }

    private bool ProcessAction()
    {
        System.Console.WriteLine("\nChoose action:");
        System.Console.WriteLine("Create account");
        System.Console.WriteLine("Deposite");
        System.Console.WriteLine("Withdraw");
        System.Console.WriteLine("Finish");
        string? command = System.Console.ReadLine();
        if (string.IsNullOrEmpty(command)) throw new ArgumentNullException();
        if (string.Equals(command, "Finish", StringComparison.OrdinalIgnoreCase))
            return false;
        return _commandHandler.Handle(command);
    }
}