using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;
public interface IBiosBuilder
{
    ICoolingSystemBuilder WithCoolingSystem(CoolingSystem.Cooler cooler);
}