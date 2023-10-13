using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.PowerUnitCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;

public class PowerUnitBuilder : IPowerUnitBuilder
{
    private PeakLoad? _peakLoad;
    public IPowerUnitBuilder WithPeakload(PeakLoad peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
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