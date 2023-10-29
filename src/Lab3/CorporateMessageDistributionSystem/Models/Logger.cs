using System;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

public class Logger : ILogger
{
    public void LogMessage(Message message)
    {
        Console.WriteLine($"Logging [{message}]");
    }
}