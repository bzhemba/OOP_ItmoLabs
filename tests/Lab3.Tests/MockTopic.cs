using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Topic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MockTopic : ITopic
{
    private string _name;
    private AdresseeProxy _proxy;
    public MockTopic(IAdressee adressee, string name, Priority minPriority)
    {
        _proxy = new AdresseeProxy(adressee, minPriority, AdresseeLogger);
        _name = name;
    }

    public MockAdresseeLogger AdresseeLogger { get; } = new MockAdresseeLogger();

    public void SendMessage(Message message)
    {
        _proxy.ReceiveMessage(message);
    }
}