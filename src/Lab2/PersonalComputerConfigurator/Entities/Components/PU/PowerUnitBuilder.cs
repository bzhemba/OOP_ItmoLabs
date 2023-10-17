using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.PowerUnitCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;

public class PowerUnitBuilder
{
    private PeakLoad? _peakLoad;
    public PowerUnitBuilder WithPeakload(PeakLoad peakLoad)
    {
        if (peakLoad is { Watt: > 0 })
        {
            _peakLoad = peakLoad;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of peak load");
        }
    }

    public PowerUnit Build()
    {
        if (_peakLoad != null)
        {
            return new PowerUnit(_peakLoad);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}