namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;

public interface IComputerDirector
{
    IComputerBuilder Direct(ComputerBuilder builder);
}