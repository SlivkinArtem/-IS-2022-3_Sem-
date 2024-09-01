using Lab5.Application.Models;

namespace Lab5.Application.Commands;

public class CreateCommand : ICommand
{
    private readonly BankService _bankService;
    private readonly Account? _account;

    public CreateCommand(BankService bankService, Account? account)
    {
        _bankService = bankService;
        _account = account;
    }

    public void Execute()
    {
        _bankService.CreateAccount(_account);
    }
}