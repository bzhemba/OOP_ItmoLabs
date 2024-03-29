using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.MessengerIntegration;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class MessengerAdressee : IAdressee
{
    private readonly Messenger _messenger;

    internal MessengerAdressee(Messenger messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(Message message)
    {
        if (message != null) _messenger.PrintMessage(message.Body);
    }
}