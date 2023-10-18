namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;

public interface IComputerDirector
{
    ComputerBuilder Direct(ComputerBuilder builder);
}