using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.MessengerIntegration;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MockConsoleWriter : IConsoleWriter
{
    private string? _text;
    public IList<string?> Messages { get; } = new List<string?>();

    public void SetText(string text)
    {
        _text = text;
    }

    public void MessageOutput()
    {
        Messages.Add(_text);
    }
}