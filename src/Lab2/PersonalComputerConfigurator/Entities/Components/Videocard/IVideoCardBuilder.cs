using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;

public interface IVideoCardBuilder
{
    IVideoCardBuilder WithVideoCardDimensions(VideoCardDimensions dimensions);
    IVideoCardBuilder WithVideoMemoryAmount(VideoMemoryAmount videoMemoryAmount);
    IVideoCardBuilder WithPciVersion(PciVersion pciVersion);
    IVideoCardBuilder WithChipFrequency(ChipFrequency chipFrequency);
    IVideoCardBuilder WithPowerConsumption(PowerConsumption powerConsumption);
    VideoCard Build();
}