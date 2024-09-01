using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressees;

public class DisplayAdressee : Adressee
{
    public override void Send(Message message)
    {
        Console.Write(message); 
    }
}