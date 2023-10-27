using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Topic;

public class TopicFacade
{
    private string _name;
    private AdresseeProxy _proxy;

    public TopicFacade(AdresseeProxy adressee, string name)
    {
        _proxy = adressee;
        _name = name;
    }

    public void SendMessage(Message message)
    {
        _proxy.GetMessage(message);
    }
}