using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.DisplayIntegration;

public class Display
{
    private DisplayDriver _displayDriver = new();

    public void ShowText(Color color)
    {
        if (_displayDriver.Message == null) return;
        string text = _displayDriver.Message;
        _displayDriver.CleanDisplay();
        text = _displayDriver.GetColoredText(text, color);
        Console.WriteLine($"(Display){text}");
    }

    public void GetText(string text)
    {
        _displayDriver.SetText(text);
    }
}