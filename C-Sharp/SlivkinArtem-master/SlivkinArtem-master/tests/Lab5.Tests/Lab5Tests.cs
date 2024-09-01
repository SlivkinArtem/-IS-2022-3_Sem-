using System;
using System.IO;
using Lab5.Application;
using Lab5.Application.CommandsHandling;
using Lab5.Application.Models;
using Lab5.Presentation.Console;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Lab5Tests
{
    [Fact]
    public void CanCreateAndGetAccount()
    {
        // Arrange
        var createCommandHandlerMock = new Mock<ICommandHandler>();
        var commandProcessor = new CommandProcessor(createCommandHandlerMock.Object);

        // Set up the user input
        string userInput = "Create\nFinish\n";
        using var consoleInput = new StringReader(userInput);
        Console.SetIn(consoleInput);

        // Act
        commandProcessor.Run();

        // Assert
        createCommandHandlerMock.Verify(h => h.Handle("Create"), Times.Once);
    }

    [Fact]
    public void CanUpdateBalance()
    {
        // Arrange
        var accountRepositoryMock = new Mock<IAccountRepository>();
        int accountNumber = 11;
        int accountPin = 1;
        int initialBalance = 0;
        int amountToAdd = 100;

        // Set up the expected behavior for GetAccount
        accountRepositoryMock.Setup(repo => repo.GetAccount(accountNumber, accountPin))
            .Returns(new Account(11, 1, 0, "b"));

        accountRepositoryMock.Setup(repo => repo.UpdateBalance(accountNumber, initialBalance + amountToAdd, accountPin));

        // Act
        var bankService = new BankService(accountRepositoryMock.Object, accountRepositoryMock.Object.GetAccount(accountNumber, accountPin));
        bankService.Deposit(accountNumber, amountToAdd, accountPin);

        accountRepositoryMock.Verify(repo => repo.GetAccount(accountNumber, accountPin), Times.AtLeastOnce);
        accountRepositoryMock.Verify(repo => repo.UpdateBalance(accountNumber, initialBalance + amountToAdd, accountPin), Times.Once);
    }
}
