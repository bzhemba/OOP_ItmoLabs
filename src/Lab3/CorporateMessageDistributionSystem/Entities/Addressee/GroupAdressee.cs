using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class GroupAdressee : IAdressee
{
    private readonly List<IAdressee> _group = new();

    public void AddAdressee(IAdressee adressee)
    {
        _group.Add(adressee);
    }

    public void RemoveAdressee(IAdressee adressee)
    {
        _group.Remove(adressee);
    }

    public void GetMessage(Message message)
    {
        foreach (IAdressee adressee in _group)
        {
            adressee.GetMessage(message);
        }
    }
}