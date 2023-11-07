using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Topic;

public class TopicFacade : ITopic
{
    private string _name;
    private IAdressee _adressee;

    public TopicFacade(IAdressee adressee, string name)
    {
        _adressee = adressee;
        _name = name;
    }

    public void SendMessage(Message message)
    {
        _adressee.ReceiveMessage(message);
    }
}