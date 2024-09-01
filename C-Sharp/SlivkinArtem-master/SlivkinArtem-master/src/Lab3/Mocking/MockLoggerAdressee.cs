using Itmo.ObjectOrientedProgramming.Lab3.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Mocking;

public class MockLoggerAdressee : Adressee
{
    private Adressee _wrappedAdressee;

    public MockLoggerAdressee(Adressee adressee)
    {
        _wrappedAdressee = adressee;
    }

    public int Counter { get; private set; }
    public override void Send(Message message)
    {
        Counter++;
        _wrappedAdressee.Send(message);
    }
}