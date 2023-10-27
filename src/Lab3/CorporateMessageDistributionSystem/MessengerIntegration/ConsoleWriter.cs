using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.MessengerIntegration;

public class ConsoleWriter
{
    private string? _text;

    public void SetText(string text)
    {
        _text = text;
    }

    public void MessageOutput()
    {
        Console.WriteLine(_text);
    }
}