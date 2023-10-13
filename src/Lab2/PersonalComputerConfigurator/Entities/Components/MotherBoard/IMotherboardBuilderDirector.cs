namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;

public interface IMotherboardBuilderDirector
{
    IMotherboardBuilder Build(IMotherboardBuilder motherboardBuilder);
}