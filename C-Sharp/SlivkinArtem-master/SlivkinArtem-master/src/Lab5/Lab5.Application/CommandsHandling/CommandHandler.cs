namespace Lab5.Application.CommandsHandling;

public abstract class CommandHandler : ICommandHandler
{
    protected ICommandHandler? NextHandler { get; private set; }

    public ICommandHandler SetNext(ICommandHandler nextHandler)
    {
        NextHandler = nextHandler ?? throw new ArgumentNullException(nameof(nextHandler));
        return NextHandler;
    }
    public abstract bool Handle(string? command);
    protected static int ReadIntInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }

            Console.WriteLine("Некорректный ввод. Попробуйте снова.");
        }
    }

    protected static string? ReadStringInput(string? prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
}