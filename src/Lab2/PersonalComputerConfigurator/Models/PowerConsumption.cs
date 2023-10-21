using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

public record PowerConsumption
{
    public PowerConsumption(int watt)
    {
        if (watt < 0)
        {
            throw new IncorrectFormatException($"Incorrect format of power consumption");
        }

        Watt = watt;
    }

    public int Watt { get; }
}