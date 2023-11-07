using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Topic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.MessengerIntegration;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CorporateMessageDistributionSystemTest
{
    private static User _user1 = new User(new List<ReadStatusMessageDecorator>());
    private static IAdressee _user1Adressee = new UserAdresseeBuilder()
        .WithUser(_user1)
        .WithPriority(Priority.Medium)
        .WithLogger(new MockAdresseeLogger())
        .Build();
    private Message _message1 = new("test", "testing test", Priority.Medium, 1);
    private Message _message2 = new("test", "testing test2", Priority.High, 2);
    private Message _message3 = new("test", "testing test3", Priority.Low, 3);
    private TopicFacade _topic = new TopicFacade(_user1Adressee, "topic for user");

    [Fact]
    public void MessageStatusUnreadTest()
    {
        _topic.SendMessage(_message1);
        MessageStatus status = _user1.GetMessageStatus(_message1);
        Assert.Equal(MessageStatus.Unread, status);
    }

    [Fact]
    public void MarkMessageAsReadTest()
    {
        _topic.SendMessage(_message1);
        _user1.MarkMessageAsRead(_message1);
        MessageStatus status = _user1.GetMessageStatus(_message1);
        Assert.Equal(MessageStatus.Read, status);
    }

    [Fact]
    public void MarkMessageAsReadThrowExceptionTest()
    {
        _topic.SendMessage(_message1);
        _topic.SendMessage(_message2);
        _user1.MarkMessageAsRead(_message2);
        Assert.Throws<AlreadyMarkedException>(
            () => _user1.MarkMessageAsRead(_message2));
    }

    [Fact]
    public void AdresseeFilteringTest()
    {
        var proxyAdresse = new MockAdresseeProxy(_user1Adressee, Priority.High);
        proxyAdresse.ReceiveMessage(_message3);
        Assert.False(proxyAdresse.Result);
    }

    [Fact]
    public void AdresseeLoggingTest()
    {
        var logger = new MockAdresseeLogger();
        logger.LogMessage(_message2);
        string result = logger.Messages[0].Body;
        Assert.Equal(_message2.Body, result);
    }

    [Fact]
    public void MessengerTest()
    {
        var mockConsoleWriter = new MockConsoleWriter();
        var messenger = new Messenger(mockConsoleWriter);
        messenger.PrintMessage(_message1.Body);
        Assert.Equal($"(Messenger) {_message1.Body}", mockConsoleWriter.Messages[0]);
    }
}