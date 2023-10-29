namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.MessengerIntegration;

public class Messenger : IMessenger
{
    private IConsoleWriter _consoleWriter;

    public Messenger(IConsoleWriter consoleWriter)
    {
        _consoleWriter = consoleWriter;
    }

    public void PrintMessage(string text)
    {
        text = $"(Messenger) {text}";
        _consoleWriter.SetText(text);
        _consoleWriter.MessageOutput();
    }
}