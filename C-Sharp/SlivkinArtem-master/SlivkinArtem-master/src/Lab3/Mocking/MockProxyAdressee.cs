using System;
using Itmo.ObjectOrientedProgramming.Lab3.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Mocking;

public class MockProxyAdressee : Adressee
{
    private Adressee _wrappedAdressee;
    private Priority _proxyPriority;

    public MockProxyAdressee(Adressee adressee, Priority priority)
    {
        _wrappedAdressee = adressee;
        _proxyPriority = priority;
    }
    public int Counter { get; private set; }
    public override void Send(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (message.Priority >= _proxyPriority)
        {
            Counter++;
            _wrappedAdressee.Send(message);
        }
    }
}