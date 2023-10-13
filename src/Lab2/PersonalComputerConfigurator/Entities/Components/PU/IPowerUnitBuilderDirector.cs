namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;

public interface IPowerUnitBuilderDirector
{
    IPowerUnitBuilder Direct(IPowerUnitBuilder builder);
}