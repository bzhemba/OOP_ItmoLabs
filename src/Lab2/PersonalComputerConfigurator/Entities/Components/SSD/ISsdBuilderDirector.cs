namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;

public interface ISsdBuilderDirector
{
    ISsdBuilder Direct(ISsdBuilder builder);
}