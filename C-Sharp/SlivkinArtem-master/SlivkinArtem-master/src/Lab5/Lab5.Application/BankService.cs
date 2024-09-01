using Lab5.Application.Models;

namespace Lab5.Application;

public class BankService : IBankService 
{
    private readonly IAccountRepository _accountRepository;

    public BankService(IAccountRepository accountRepository, Account? currentAccount)
    {
        _accountRepository = accountRepository;
        CurrentAccount = currentAccount;
    }
    public Account? CurrentAccount { get; private set; }
    
    public void SetCurrentAccount(Account? account)
    {
        CurrentAccount = account;
    }

    public void CreateAccount(Account? account)
    {
        _accountRepository.CreateAccount(account);
    }

    public void Deposit(int accountNumber, int amount, int accountPin)
    {
        if (amount < 0) throw new ArithmeticException("Sorry");
        Account? account = _accountRepository.GetAccount(accountNumber, accountPin);
        ArgumentNullException.ThrowIfNull(account);
        amount += account.Balance;
        _accountRepository.UpdateBalance(accountNumber, amount, accountPin);
    }

    public void Withdraw(int accountNumber, int amount, int accountPin)
    {
        if (amount < 0) throw new ArithmeticException("Sorry");
        Account? account = _accountRepository.GetAccount(accountNumber, accountPin);
        ArgumentNullException.ThrowIfNull(account);
        amount = account.Balance - amount;
        _accountRepository.UpdateBalance(accountNumber, amount, accountPin);
    }
}