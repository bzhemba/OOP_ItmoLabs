using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

public class User
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
        _messages.Add(message);
    }
}