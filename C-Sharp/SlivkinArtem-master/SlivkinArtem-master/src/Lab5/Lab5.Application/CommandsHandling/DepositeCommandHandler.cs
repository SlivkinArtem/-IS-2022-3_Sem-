using Lab5.Application.Commands;

namespace Lab5.Application.CommandsHandling;

public class DepositeCommandHandler : CommandHandler
{
    private readonly BankService _bankService;

    public DepositeCommandHandler(BankService bankService)
    {
        _bankService = bankService;
    }

    public override bool Handle(string? command)
    {
        Console.WriteLine($"Handling command '{command}' in DepositeCommandHandler");
        if (command == "Deposite")
        {
            Console.Write("Введите сумму для пополнения: ");
            string? amountInput = Console.ReadLine();

            if (int.TryParse(amountInput, out int amount))
            {
                ArgumentNullException.ThrowIfNull(_bankService.CurrentAccount);
                var depositeCommand = new DepositeCommand(_bankService, _bankService.CurrentAccount, amount);
                depositeCommand.Execute();
                Console.WriteLine("Счет успешно пополнен!");
            }
            else
            {
                Console.WriteLine("Некорректный ввод для суммы. Попробуйте снова.");
            }
            return true;
        }
        return NextHandler?.Handle(command) ?? false;    
    }
}