using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class User : IAdressee
{
    private List<ReadStatusMessageDecorator> _messages = new();

    public MessageStatus GetMessageStatus(Message message)
    {
        foreach (ReadStatusMessageDecorator receivedMessage in _messages)
        {
            if (message != null && receivedMessage.Id == message.Id && receivedMessage.IsRead)
            {
                return MessageStatus.Read;
            }
            else if (message != null && receivedMessage.Id == message.Id && !receivedMessage.IsRead)
            {
                return MessageStatus.Unread;
            }
        }

        throw new ArgumentException($"This message doesn't exist");
    }

    public void GetMessage(Message message)
    {
        var decoratedMessage = new ReadStatusMessageDecorator(message);
        _messages.Add(decoratedMessage);
    }

    public void MarkMessageAsRead(Message message)
    {
        foreach (ReadStatusMessageDecorator receivedMessage in _messages)
        {
            if (message != null && receivedMessage.Id == message.Id && !receivedMessage.IsRead)
            {
                receivedMessage.ChangeStatus();
                return;
            }
            else if (message != null && receivedMessage.Id == message.Id && receivedMessage.IsRead)
            {
                throw new AlreadyMarkedException($"This message has already been marked");
            }
        }

        throw new ArgumentException($"This message doesn't exist");
    }
}