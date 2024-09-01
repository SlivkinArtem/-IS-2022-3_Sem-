using System;
using Itmo.ObjectOrientedProgramming.Lab3.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Mocking;

public class MockMessenger : MessengerAdressee
{
    public int Counter { get; private set; }
    public override void Send(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        Counter++;
        Console.WriteLine("Messenger: " + message.Body);
    }
}