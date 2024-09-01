using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressees;

public class GroupAdressee : Adressee
{
    private ICollection<Adressee> _adresses;

    public GroupAdressee(ICollection<Adressee> adresses)
    {
        _adresses = adresses;
    }

    public void AddAdressee(Adressee adressee)
    {
        ArgumentNullException.ThrowIfNull(adressee);
        _adresses.Add(adressee);
    }
    
    public void DeleteAdressee(Adressee adressee)
    {
        ArgumentNullException.ThrowIfNull(adressee);
        _adresses.Remove(adressee);
    }

    public override void Send(Message message)
    {
        foreach (Adressee adressee in _adresses)
            adressee.Send(message);
    }
}