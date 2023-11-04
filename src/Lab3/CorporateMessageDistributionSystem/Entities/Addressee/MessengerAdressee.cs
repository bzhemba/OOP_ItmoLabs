using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.MessengerIntegration;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class MessengerAdressee : IAdressee
{
    private readonly Messenger _messenger;
    private Priority _priority;
    private ILogger _logger;

    internal MessengerAdressee(Messenger messenger, Priority priority, ILogger logger)
    {
        _messenger = messenger;
        _priority = priority;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        if (message != null) _messenger.PrintMessage(message.Body);
    }
}