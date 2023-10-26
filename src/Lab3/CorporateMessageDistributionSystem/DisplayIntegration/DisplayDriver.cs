using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.DisplayIntegration;

internal class DisplayDriver
{
    public string? Message { get; private set; }

    public string GetColoredText(string text, Color color)
    {
        Message = Crayon.Output.Rgb(color.R, color.G, color.B).Text(text);
        return Message;
    }

    public void CleanDisplay()
    {
        Message = null;
        Console.Clear();
    }

    public void SetText(string text)
    {
        Message = text;
    }
}