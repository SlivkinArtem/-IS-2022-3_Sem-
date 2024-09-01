using System;
using Itmo.ObjectOrientedProgramming.Lab3.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class LoggerAdressee : Adressee
{
    private Adressee _wrappedAdressee;

    public LoggerAdressee(Adressee adressee)
    {
        _wrappedAdressee = adressee;
    }
    
    public override void Send(Message message)
    {
        Console.WriteLine("Message log");
        _wrappedAdressee.Send(message);
    }
}