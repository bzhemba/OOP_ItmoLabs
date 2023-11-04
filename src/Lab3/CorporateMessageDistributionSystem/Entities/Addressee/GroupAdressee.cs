using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class GroupAdressee : IAdressee
{
    private readonly ICollection<IAdressee> _group;
    private Priority _priority;
    private ILogger _logger;

    public GroupAdressee(ICollection<IAdressee> group, Priority priority, ILogger logger)
    {
        _priority = priority;
        _logger = logger;
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