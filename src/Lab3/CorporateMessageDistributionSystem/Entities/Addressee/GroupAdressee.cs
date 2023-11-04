using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class GroupAdressee : IAdressee
{
    private Group _group;
    internal GroupAdressee(Group group)
    {
        _group = group;
    }

    public void ReceiveMessage(Message message)
    {
        _group.ReceiveMessage(message);
    }
}