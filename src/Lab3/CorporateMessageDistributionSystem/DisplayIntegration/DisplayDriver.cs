using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.DisplayIntegration;

public class DisplayDriver
{
    public string? Message { get; private set; }

    public void SetColor(Color color)
    {
        if (Message == null) return;
        string coloredText = Crayon.Output.Rgb(color.R, color.G, color.B).Text(Message);
        SetText(coloredText);
    }

    public void CleanDisplay()
    {
        Message = null;
    }

    public void SetText(string text)
    {
        Message = text;
    }
}