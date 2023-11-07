using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class UserAdressee : IAdressee
{
    private User _user;

    internal UserAdressee(User user)
    {
        _user = user;
    }

    public void ReceiveMessage(Message message)
    {
        _user.ReceiveMessage(message);
    }
}