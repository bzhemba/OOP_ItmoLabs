using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Topic;

public class TopicFacade : ITopic
{
    private string _name;
    private AdresseeProxy _proxy;

    public TopicFacade(IAdressee adressee, string name, Priority minPriority)
    {
        _proxy = new AdresseeProxy(adressee, minPriority, new Logger());
        _name = name;
    }

    public void SendMessage(Message message)
    {
        _proxy.GetMessage(message);
    }
}