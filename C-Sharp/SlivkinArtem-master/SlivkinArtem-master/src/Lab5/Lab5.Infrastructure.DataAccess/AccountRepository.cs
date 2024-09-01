using Lab5.Application.Models;
using Npgsql;

namespace Lab5.Infrastructure.DataAcess;

public class AccountRepository : IAccountRepository
{
    private readonly string? _connectionProvider;
    public AccountRepository(string connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Account? GetAccount(int accountNumber, int pin)
    {
        const string sql = """
                           SELECT account_number, pin, balance, user_name 
                           FROM accounts 
                           WHERE account_number = @accountNumber AND pin = @pin;
                           """;

        using var connection = new NpgsqlConnection(_connectionProvider);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("accountNumber", accountNumber);
        command.Parameters.AddWithValue("pin", pin);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new Account(
            accountNumber: reader.GetInt32(0),
            pin: reader.GetInt32(1),
            balance: reader.GetInt32(2),
            userName: reader.GetString(3));
    }

    public void CreateAccount(Account? account)
    {
        const string sql = @"
                           INSERT INTO accounts (account_number, pin, balance, user_name) 
                           VALUES (@accountNumber, @pin, @balance, @userName);
                           ";

        using var connection = new NpgsqlConnection(_connectionProvider);
        connection.Open();

        ArgumentNullException.ThrowIfNull(account);

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("accountNumber", account.AccountNumber);
        command.Parameters.AddWithValue("pin", account.Pin);
        command.Parameters.AddWithValue("balance", account.Balance);
        ArgumentNullException.ThrowIfNull(account.UserName);
        command.Parameters.AddWithValue("userName", account.UserName);

        command.ExecuteNonQuery();
    }

    public void UpdateBalance(int accountNumber, int amount, int pin)
    {
        const string sql = @"
                            update accounts
                            SET balance = @amount
                            WHERE account_number = @accountNumber AND pin = @pin;
                            ";
        using var connection = new NpgsqlConnection(_connectionProvider);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("amount", amount);
        command.Parameters.AddWithValue("accountNumber", accountNumber);
        command.Parameters.AddWithValue("pin", pin);

        command.ExecuteNonQuery();
    }
}
