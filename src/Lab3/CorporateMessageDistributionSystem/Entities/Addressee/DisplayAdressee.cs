using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.DisplayIntegration;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class DisplayAdressee : IAdressee
{
    private readonly Display _display;

    internal DisplayAdressee(Display display)
    {
        _display = display;
    }

    public void ReceiveMessage(Message message)
    {
        if (message != null) _display.GetText(message.Body);
    }
}