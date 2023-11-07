using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class AdresseeProxy : IAdressee
{
    private readonly IAdressee _adressee;
    private Priority _minPriority;

    public AdresseeProxy(IAdressee adressee, Priority minPriority)
    {
        _adressee = adressee;
        _minPriority = minPriority;
    }

    public Priority MessagePriority { get; }

    public void ReceiveMessage(Message message)
    {
        if (message == null) return;

        if (!this.CheckAccess(message)) return;

        _adressee.ReceiveMessage(message);
    }

    private bool CheckAccess(Message message)
    {
        return message.Priority >= _minPriority;
    }
}