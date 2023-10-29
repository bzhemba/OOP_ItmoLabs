using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Topic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Services;

internal class Program
{
    public static void Main()
    {
        User user1 = new();
        Message message1 = new("test", "testing test", Priority.Medium, 1);
        Message message2 = new("test", "testing test2", Priority.Low, 2);
        var topic = new TopicFacade(user1, "topic for user", Priority.Medium);
        topic.SendMessage(message1);
        topic.SendMessage(message2);
        user1.MarkMessageAsRead(message2);
    }
}