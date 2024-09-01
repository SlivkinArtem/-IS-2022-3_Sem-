using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    public void Send(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        Console.WriteLine("Messenger: " + message.Body);
    }
}