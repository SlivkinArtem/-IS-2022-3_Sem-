namespace Lab5.Application.Models;

public class Account
{
    public Account(int accountNumber, int pin, int balance, string? userName)
    {
        if (accountNumber <= 0 || pin <= 0 || userName == null) return;
        AccountNumber = accountNumber;
        Pin = pin;
        Balance = balance;
        UserName = userName;
    }

    public string? UserName { get; }
    public int AccountNumber { get; }
    public int Pin { get; }
    public int Balance { get; }
}