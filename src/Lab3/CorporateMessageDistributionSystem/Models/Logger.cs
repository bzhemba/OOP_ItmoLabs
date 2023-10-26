using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

public class Logger
{
    private IList<Message> _messages;

    public Logger()
    {
        _messages = new List<Message>();
    }

    public void LogMessage(Message message)
    {
        _messages.Add(message);
    }
}