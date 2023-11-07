using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class AdresseeLogger : IAdressee
{
    private readonly IAdressee _adressee;
    private readonly ILogger _logger;

    public AdresseeLogger(IAdressee adressee, ILogger logger)
    {
        _adressee = adressee;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        _logger.LogMessage(message);
        _adressee.ReceiveMessage(message);
    }
}