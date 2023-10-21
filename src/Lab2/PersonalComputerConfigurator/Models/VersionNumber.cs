using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

public record VersionNumber
{
    public VersionNumber(int version)
    {
        if (version < 0)
        {
            throw new IncorrectFormatException($"Incorrect format of version");
        }

        Version = version;
    }

    public int Version { get; }
}