using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.DisplayIntegration;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class DisplayAdressee : IAdressee
{
    private readonly Display _display;
    private Priority _priority;
    private ILogger _logger;

    internal DisplayAdressee(Display display, Priority priority, ILogger logger)
    {
        _display = display;
        _priority = priority;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        if (message != null) _display.GetText(message.Body);
    }
}