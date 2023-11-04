using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class UserAdressee : IAdressee
{
    private ICollection<ReadStatusMessageDecorator> _messages;
    private Priority _priority;
    private ILogger _logger;

    public UserAdressee(ICollection<ReadStatusMessageDecorator> messages, Priority priority, ILogger logger)
    {
        _messages = messages;
        _priority = priority;
        _logger = logger;
    }

    public MessageStatus GetMessageStatus(Message message)
    {
        ReadStatusMessageDecorator receivedMessage =
            _messages.FirstOrDefault(received => received.Id == message.Id)
            ?? throw new ArgumentException($"This message doesn't exist");
        return !receivedMessage.IsRead ? MessageStatus.Unread : MessageStatus.Read;
    }

    public void ReceiveMessage(Message message)
    {
        var decoratedMessage = new ReadStatusMessageDecorator(message);
        _messages.Add(decoratedMessage);
    }

    public void MarkMessageAsRead(Message message)
    {
        ReadStatusMessageDecorator receivedMessage =
            _messages.FirstOrDefault(received => received.Id == message.Id)
            ?? throw new ArgumentException($"This message doesn't exist");
        if (!receivedMessage.IsRead)
        {
            receivedMessage.ChangeStatus();
            return;
        }
        else if (receivedMessage.IsRead)
        {
            throw new AlreadyMarkedException($"This message has already been marked");
        }
    }
}