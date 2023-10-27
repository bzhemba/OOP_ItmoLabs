using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Topic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CorporateMessageDistributionSystemTest
{
    private static UserAdressee _user1 = new();
    private static AdresseeProxy _userAdressee = new AdresseeProxy(_user1, Priority.Medium);
    private Message _message1 = new("test", "testing test", Priority.Medium);
    private Message _message2 = new("test", "testing test2", Priority.Low);
    private TopicFacade _topic = new TopicFacade(_userAdressee, "topic for user");
    [Fact]
    public void MessageStatusUnread()
    {
        _topic.SendMessage(_message1);
        _topic.SendMessage(_message2);
        _user1.
    }
}