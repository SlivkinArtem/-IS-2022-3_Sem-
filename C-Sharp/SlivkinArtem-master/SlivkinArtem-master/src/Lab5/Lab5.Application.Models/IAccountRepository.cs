namespace Lab5.Application.Models;

public interface IAccountRepository
{
    void CreateAccount(Account? account);
    Account? GetAccount(int accountNumber, int pin);
    void UpdateBalance(int accountNumber, int amount, int pin);
}