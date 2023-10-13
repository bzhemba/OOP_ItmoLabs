namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;

public interface IRamBuilderDirector
{
    IRamBuilder Direct(IRamBuilder builder);
}