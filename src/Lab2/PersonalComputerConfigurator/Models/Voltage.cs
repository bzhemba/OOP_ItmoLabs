using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

public record Voltage
{
    public Voltage(double v)
    {
        if (v < 0)
        {
            throw new IncorrectFormatException($"Incorrect format of voltage");
        }

        V = v;
    }

    public double V { get; }
}