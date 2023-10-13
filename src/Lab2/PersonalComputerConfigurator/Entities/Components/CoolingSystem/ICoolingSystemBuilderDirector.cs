namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;

public interface ICoolingSystemBuilderDirector
{
    ICoolingSystemBuilder Direct(ICoolingSystemBuilder coolingSystemBuilder);
}