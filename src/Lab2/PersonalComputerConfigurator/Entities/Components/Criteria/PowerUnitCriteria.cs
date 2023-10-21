using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.PowerUnitCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class PowerUnitCriteria
{
    public PowerUnitCriteria(PeakLoad? peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public PeakLoad? PeakLoad { get; }
}