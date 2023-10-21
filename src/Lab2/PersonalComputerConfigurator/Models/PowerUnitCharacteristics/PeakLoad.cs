using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.PowerUnitCharacteristics;

public record PeakLoad
{
    public PeakLoad(int watt)
    {
        if (watt < 0)
        {
            throw new IncorrectFormatException($"Incorrect format of power consumption");
        }

        Watt = watt;
    }

    public int Watt { get; }
}