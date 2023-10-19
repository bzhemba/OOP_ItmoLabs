using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCase;

public interface ISystemCaseBuilder
{
    IPowerUnitBuilder WithPowerUnit(PowerUnit powerUnit);
}