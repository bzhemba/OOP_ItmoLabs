using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.PowerUnitCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;

public class PowerUnit
{
    private PeakLoad _peakLoad;

    public PowerUnit(PeakLoad peakLoad)
    {
        _peakLoad = peakLoad;
    }
}