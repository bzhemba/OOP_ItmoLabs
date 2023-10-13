namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;

public interface IVideoCardBuilderDirector
{
    IVideoCardBuilder Direct(IVideoCardBuilder builder);
}