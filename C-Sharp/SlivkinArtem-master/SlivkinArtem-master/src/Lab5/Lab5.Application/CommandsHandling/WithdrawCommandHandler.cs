using Lab5.Application.Commands;

namespace Lab5.Application.CommandsHandling;

public class WithdrawCommandHandler : CommandHandler
{
    private readonly BankService _bankService;

    public WithdrawCommandHandler(BankService bankService)
    {
        _bankService = bankService;
    }

    public override bool Handle(string? command)
    {
        if (command == "Withdraw")
        {
            Console.Write("Введите сумму для снятия: ");
            string? amountInput = Console.ReadLine();

            if (int.TryParse(amountInput, out int amount))
            {
                ArgumentNullException.ThrowIfNull(_bankService.CurrentAccount);
                var withdrawCommand = new WithdrawCommand(_bankService, _bankService.CurrentAccount, amount);
                withdrawCommand.Execute();
                Console.WriteLine("Сумма успешно списана");
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