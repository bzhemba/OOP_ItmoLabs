using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;

public interface IXmpBuilder
{
    IVideoCardBuilder WithVideoCard(VideoCard? videoCard);
}