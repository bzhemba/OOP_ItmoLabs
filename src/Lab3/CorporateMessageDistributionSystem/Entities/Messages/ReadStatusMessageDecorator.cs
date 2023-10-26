using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models.MessageAtrributes;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

public class ReadStatusMessageDecorator : IMessage
{
    private Message _message;
    public ReadStatusMessageDecorator(Message message)
    {
        _message = message;
    }

    public Text Header => _message.Header;
    public Text Body => _message.Body;
    public bool ReadStatus { get; private set; }

    public void MarkAsRead()
    {
        if (ReadStatus)
        {
            throw new AlreadyMarkedException($"Can't mark this message as read");
        }

        ReadStatus = true;
    }
}