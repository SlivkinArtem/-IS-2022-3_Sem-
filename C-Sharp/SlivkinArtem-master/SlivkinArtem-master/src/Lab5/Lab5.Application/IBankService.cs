using Lab5.Application.Models;

namespace Lab5.Application;

public interface IBankService
{
    public void SetCurrentAccount(Account? account);
    public void CreateAccount(Account? account);
    public void Deposit(int accountNumber, int amount, int accountPin);
    public void Withdraw(int accountNumber, int amount, int accountPin);
}