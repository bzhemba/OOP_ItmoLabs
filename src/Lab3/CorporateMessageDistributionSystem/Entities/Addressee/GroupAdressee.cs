using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class GroupAdressee : IAdressee
{
    private readonly IReadOnlyCollection<IAdressee> _group;

    public GroupAdressee(IReadOnlyCollection<IAdressee> group)
    {
        _group = group;
    }

    public void GetMessage(Message message)
    {
        foreach (IAdressee adressee in _group)
        {
            adressee.GetMessage(message);
        }
    }
}