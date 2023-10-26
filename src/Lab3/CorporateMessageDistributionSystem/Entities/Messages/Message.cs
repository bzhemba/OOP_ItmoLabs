using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

public class Message : IMessage
{
    public Message(string header, string body, Priority priority)
    {
        Header = header;
        Body = body;
        Priority = priority;
    }

    public Priority Priority { get; }
    public string Header { get; }
    public string Body { get; }
}