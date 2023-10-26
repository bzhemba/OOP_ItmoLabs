using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class UserAdressee : IAdressee
{
    private List<IMessage> _messages = new List<IMessage>();
    private List<IMessage> _seenMessages = new List<IMessage>();
    public void MarkMessageAsRead(Message message)
    {
        if (_seenMessages.Contains(message))
        {
            throw new ArgumentException("This message has already been marked.");
        }

        _seenMessages.Add(message);
    }

    public MessageStatus GetMessageStatus(Message message)
    {
        if (_seenMessages.Contains(message))
        {
            return MessageStatus.Read;
        }

        if (_messages.Contains(message))
        {
            return MessageStatus.Unread;
        }

        throw new ArgumentException("This message does not exist.");
    }

    public void GetMessage(Message message)
    {
        var decoratedMessage = new ReadStatusMessageDecorator(message);
        _messages.Add(decoratedMessage);
    }
}