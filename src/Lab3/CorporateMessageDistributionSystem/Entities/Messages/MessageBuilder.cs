using System;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Messages;

public class MessageBuilder
{
    private string? _header;
    private string? _body;
    private Priority _priority;
    private int? _id;

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

    public MessageBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    public Message Build()
    {
        return new Message(
            _header ?? throw new ArgumentNullException(nameof(_header)),
            _body ?? throw new ArgumentNullException(nameof(_body)),
            _priority,
            _id ?? throw new ArgumentNullException(nameof(_id)));
    }
}