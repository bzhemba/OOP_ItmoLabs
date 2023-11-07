using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

public class ReadStatusMessageDecorator : IMessage
{
    private Message _message;

    public ReadStatusMessageDecorator(Message message)
    {
        _message = message;
        Header = _message.Header;
        Body = _message.Body;
        Id = _message.Id;
        Priority = _message.Priority;
    }

    public bool IsRead { get; private set; }
    public string Header { get; }
    public string Body { get; }
    public int Id { get; }
    public Priority Priority { get; }
    public void ChangeStatus()
    {
        if (!IsRead)
        {
            IsRead = true;
        }
    }
}
