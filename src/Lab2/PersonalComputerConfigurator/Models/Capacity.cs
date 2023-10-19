using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

public record Capacity
{
    public Capacity(int gb)
    {
        if (gb < 0)
        {
            throw new IncorrectFormatException($"Incorrect format of dimensions");
        }

        Gb = gb;
    }

    public int Gb { get; }
}