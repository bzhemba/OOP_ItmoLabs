namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;

public interface IBiosBuilderDirector
{
    IBiosBuilder Direct(IBiosBuilder builder);
}