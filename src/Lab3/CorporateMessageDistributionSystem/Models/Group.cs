using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

public class Group
{
    private readonly ICollection<IAdressee> _group;

    public Group(ICollection<IAdressee> group)
    {
        _group = group;
    }

    public void AddAdressee(IAdressee adressee)
    {
        _group.Add(adressee);
    }

    public void RemoveAdressee(IAdressee adressee)
    {
        _group.Remove(adressee);
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IAdressee adressee in _group)
        {
            adressee.ReceiveMessage(message);
        }
    }
}