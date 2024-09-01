using Lab5.Application;
using Lab5.Application.CommandsHandling;
using Lab5.Infrastructure.DataAcess;
using Lab5.Presentation.Console;

namespace Lab5;

internal class Program
{
    private static void Main()
    {
        string connectionString = "Host=localhost;" +
                                  "Port=5432;" +
                                  "Database=postgres;" +
                                  "Username=postgres;" +
                                  "Password=gangkek;";
        var accountRepository = new AccountRepository(connectionString);
        var bankService = new BankService(accountRepository, null);
        var createHandler = new CreateCommandHandler(bankService);
        createHandler.SetNext(new DepositeCommandHandler(bankService));
        var commandProcessor = new CommandProcessor(createHandler);
        commandProcessor.Run();
    }
}
