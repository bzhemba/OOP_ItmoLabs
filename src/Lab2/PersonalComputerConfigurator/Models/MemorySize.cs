using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

public record MemorySize
{
    public MemorySize(int gb)
    {
        if (gb < 0)
        {
            throw new IncorrectFormatException($"Incorrect format of power consumption");
        }

        Gb = gb;
    }

    public int Gb { get; }
}