using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Lab4Tests
{
    [Fact]
    public void ProcessActionShouldInvokeConnectHandlerWhenConnectCommandIsGiven()
    {
        var connectHandlerMock = new Mock<ICommandHandler>();
        var disconnectHandlerMock = new Mock<ICommandHandler>();

        connectHandlerMock
            .Setup(h => h.SetNext(It.IsAny<ICommandHandler>()))
            .Returns<ICommandHandler>(nextHandler => nextHandler);

        disconnectHandlerMock
            .Setup(h => h.SetNext(It.IsAny<ICommandHandler>()))
            .Returns<ICommandHandler>(nextHandler => nextHandler);

        var commandProcessor = new CommandProcessor(connectHandlerMock.Object);

        string userInput = "Connect Address Local\nFinish\n"; // Сначала Connect, затем пользователь вводит Finish
        using var consoleInput = new StringReader(userInput);
        Console.SetIn(consoleInput);

        // Act
        commandProcessor.Run();

        // Assert
        connectHandlerMock.Verify(h => h.Handle(It.IsAny<string>(), It.IsAny<string[]>()), Times.Once);
        disconnectHandlerMock.Verify(h => h.Handle(It.IsAny<string>(), It.IsAny<string[]>()), Times.Never);
    }
}