using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressees;

public abstract class Adressee
{
    public abstract void Send(Message message);
}