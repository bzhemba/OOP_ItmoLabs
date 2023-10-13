using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.PowerUnitCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;

public interface IPowerUnitBuilder
{
    IPowerUnitBuilder WithPeakload(PeakLoad peakLoad);
    PowerUnit Build();
}