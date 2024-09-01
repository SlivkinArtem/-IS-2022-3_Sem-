using Lab5.Application.Commands;
using Lab5.Application.Models;

namespace Lab5.Application.CommandsHandling;

public class CreateCommandHandler : CommandHandler
{
    private readonly BankService _bankService;

    public CreateCommandHandler(BankService bankService)
    {
        _bankService = bankService;
    }

    public override bool Handle(string? command)
    {
        Console.WriteLine($"Handling command '{command}' in CreateCommandHandler");
        if (command == "Create")
        {
            int accountNumber = ReadIntInput("Введите номер аккаунта: ");
            int pin = ReadIntInput("Введите ПИН-код: ");
            int balance = ReadIntInput("Введите начальный баланс: ");
            string? userName = ReadStringInput("Введите имя пользователя: ");

            var newAccount = new Account(accountNumber, pin, balance, userName);
            var createCommand = new CreateCommand(_bankService, newAccount);
            createCommand.Execute();
            _bankService.SetCurrentAccount(newAccount);
            Console.WriteLine("Аккаунт успешно создан!");
            return true;
        }
        return NextHandler?.Handle(command) ?? false;
    }
}