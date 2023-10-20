namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;

public interface IBiosDirector
{
    BiosBuilder Direct(BiosBuilder builder);
}