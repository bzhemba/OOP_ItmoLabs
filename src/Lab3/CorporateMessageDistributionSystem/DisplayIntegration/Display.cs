using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.DisplayIntegration;

public class Display
{
    private DisplayDriver _displayDriver;

    public Display(DisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void ShowText(Color color)
    {
        if (_displayDriver.Message == null) return;
        Console.Clear();
        _displayDriver.SetColor(color);
        Console.WriteLine($"(Display){_displayDriver.Message}");
    }

    public void GetText(string text)
    {
        _displayDriver.SetText(text);
    }
}