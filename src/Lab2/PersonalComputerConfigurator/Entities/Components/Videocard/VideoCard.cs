using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;

public class VideoCard : IVideoCardBuilderDirector
{
    private VideoCardDimensions _dimensions;
    private VideoMemoryAmount _videoMemoryAmount;
    private PciVersion _pciVersion;
    private ChipFrequency _chipFrequency;
    private PowerConsumption _powerConsumption;

    public VideoCard(VideoCardDimensions dimensions, VideoMemoryAmount videoMemoryAmount, PciVersion pciVersion, ChipFrequency chipFrequency, PowerConsumption powerConsumption)
    {
        _dimensions = dimensions;
        _videoMemoryAmount = videoMemoryAmount;
        _pciVersion = pciVersion;
        _chipFrequency = chipFrequency;
        _powerConsumption = powerConsumption;
    }

    public IVideoCardBuilder Direct(IVideoCardBuilder builder)
    {
        if (builder != null)
        {
            builder.WithChipFrequency(_chipFrequency);
            builder.WithPciVersion(_pciVersion);
            builder.WithPowerConsumption(_powerConsumption);
            builder.WithVideoMemoryAmount(_videoMemoryAmount);
            builder.WithVideoCardDimensions(_dimensions);
            return builder;
        }
        else
        {
            throw new NullObjectException("Builder is empty");
        }
    }
}