using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCase;

public interface ISystemUnitBuilder
{
    IPowerUnitBuilder WithPowerUnit(PowerUnit powerUnit);
}