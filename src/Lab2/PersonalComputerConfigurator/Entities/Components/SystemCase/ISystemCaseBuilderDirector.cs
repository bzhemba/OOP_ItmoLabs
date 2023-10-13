namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCase;

public interface ISystemCaseBuilderDirector
{
    ISystemCaseBuilder Direct(ISystemCaseBuilder builder);
}