using System;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressees;

public class ProxyAdressee : Adressee
{
    private Adressee _wrappedAdressee;
    private Priority _proxyPriority;

    public ProxyAdressee(Adressee adressee, Priority priority)
    {
        _wrappedAdressee = adressee;
        _proxyPriority = priority;
    }

    public override void Send(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (message.Priority >= _proxyPriority)
            _wrappedAdressee.Send(message);
    }
}