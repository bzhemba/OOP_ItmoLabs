using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MockAdresseeProxy : IAdressee
{
    private readonly IAdressee _adressee;
    private Priority _minPriority;
    public MockAdresseeProxy(IAdressee adressee, Priority minPriority)
    {
        _adressee = adressee;
        _minPriority = minPriority;
    }

    public Priority MessagePriority { get; }
    public bool Result { get; private set; }

    public void ReceiveMessage(Message message)
    {
        if (message == null) return;
        if (!this.CheckAccess(message))
        {
            Result = false;
        }
        else
        {
            Result = true;
        }
    }

    private bool CheckAccess(Message message)
    {
        return message.Priority >= _minPriority;
    }
    }