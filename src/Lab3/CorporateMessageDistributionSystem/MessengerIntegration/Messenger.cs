namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.MessengerIntegration;

public class Messenger
{
    private ConsoleWriter _consoleWriter;

    public Messenger()
    {
        _consoleWriter = new ConsoleWriter();
    }

    public void PrintMessage(string text)
    {
        text = $"(Messenger) {text}";
        _consoleWriter.SetText(text);
        _consoleWriter.MessageOutput();
    }
}