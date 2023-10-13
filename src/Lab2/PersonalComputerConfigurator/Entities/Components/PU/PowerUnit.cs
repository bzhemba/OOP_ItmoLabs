using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.PowerUnitCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;

public class PowerUnit : IPowerUnitBuilderDirector
{
    private PeakLoad _peakLoad;

    public PowerUnit(PeakLoad peakLoad)
    {
        _peakLoad = peakLoad;
    }

    public IPowerUnitBuilder Direct(IPowerUnitBuilder builder)
    {
        if (builder != null)
        {
            builder.WithPeakload(_peakLoad);
            return builder;
        }
        else
        {
            throw new NullObjectException("Builder is empty");
        }
    }
}