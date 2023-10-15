using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;

public interface IComputerBuilder
{
    IMotherboardBuilder WithMotherBoard(Motherboard motherboard);
}