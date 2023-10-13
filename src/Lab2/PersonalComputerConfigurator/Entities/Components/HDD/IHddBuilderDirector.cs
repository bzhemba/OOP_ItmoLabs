namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;

public interface IHddBuilderDirector
{
    IHddBuilder Direct(IHddBuilder builder);
}