using Lab5.Application.Models;

namespace Lab5.Application.Commands;

public class WithdrawCommand : ICommand
{
    private readonly BankService _bankService;
    private readonly Account _account;
    private readonly int _amount;

    public WithdrawCommand(BankService bankService, Account account, int amount)
    {
        if (amount < 0) throw new ArithmeticException("Sorry");
        _bankService = bankService;
        _account = account;
        _amount = amount;
    }
    
    public void Execute()
    {
        _bankService.Withdraw(_account.AccountNumber, _amount, _account.Pin);
    }
}