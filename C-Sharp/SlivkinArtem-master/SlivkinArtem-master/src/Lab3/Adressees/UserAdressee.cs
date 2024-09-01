using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressees;

public class UserAdressee : Adressee
{
    private User? _user;

    public UserAdressee(User? user)
    {
        _user = user;
    }

    public override void Send(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(_user);
        _user.AddMessage(message);
    }
}