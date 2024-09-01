using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressees;

public class MessengerAdressee : Adressee
{
    public override void Send(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        Console.WriteLine("Messenger: " + message.Body);
    }
}