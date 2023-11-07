using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MockAdresseeLogger : ILogger
{
    public IList<Message> Messages { get; } = new List<Message>();

    public void LogMessage(Message message)
    {
        Messages.Add(message);
    }
}