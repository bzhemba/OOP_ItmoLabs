using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

public interface IMessage
{
    string Header { get;  }
    string Body { get; }
    public int Id { get; }
    public Priority Priority { get; }
}