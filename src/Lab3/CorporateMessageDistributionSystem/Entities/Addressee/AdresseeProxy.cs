using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class AdresseeProxy : IAdressee
{
    private readonly IAdressee _adressee;
    private Priority _minPriority;
    private Logger _logger;

    public AdresseeProxy(IAdressee adressee, Priority minPriority)
    {
        _adressee = adressee;
        _minPriority = minPriority;
        _logger = new Logger();
    }

    public Priority MessagePriority { get; }

    public void GetMessage(Message message)
    {
        if (message == null) return;
        if (!this.CheckAccess(message)) return;
        _logger.LogMessage(message);
        _adressee.GetMessage(message);
    }

    private bool CheckAccess(Message message)
    {
        return message.Priority <= _minPriority;
    }
}