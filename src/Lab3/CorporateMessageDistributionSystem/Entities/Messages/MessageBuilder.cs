using System;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

public class MessageBuilder
{
    private string? _header;
    private string? _body;
    private Priority _priority;

    public MessageBuilder WithHeader(string header)
    {
        _header = header;
        return this;
    }

    public MessageBuilder WithText(string body)
    {
        _body = body;
        return this;
    }

    public MessageBuilder WithPriority(Priority priority)
    {
        _priority = priority;
        return this;
    }

    public Message Build()
    {
        return new Message(
            _header ?? throw new ArgumentNullException(nameof(_header)),
            _body ?? throw new ArgumentNullException(nameof(_body)),
            _priority);
    }
}