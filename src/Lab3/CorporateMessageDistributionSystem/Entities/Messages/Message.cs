using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

public class Message : IMessage
{
    public Message(string header, string body, Priority priority, int id)
    {
        Header = header;
        Body = body;
        Priority = priority;
        Id = id;
    }

    public int Id { get; }
    public Priority Priority { get; }
    public string Header { get; }
    public string Body { get; }
}