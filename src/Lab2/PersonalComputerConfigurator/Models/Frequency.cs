using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

public record Frequency
{
    public Frequency(int mhz)
    {
        if (mhz < 0)
        {
            throw new IncorrectFormatException($"Incorrect format of frequency");
        }

        Mhz = mhz;
    }

    public int Mhz { get; }
}