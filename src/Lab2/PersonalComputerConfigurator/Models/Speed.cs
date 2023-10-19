using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

public record Speed
{
    public Speed(int mbS)
    {
        if (mbS <= 0)
        {
            throw new IncorrectFormatException($"Incorrect format of speed");
        }

        MbS = mbS;
    }

    public int MbS { get; }
}