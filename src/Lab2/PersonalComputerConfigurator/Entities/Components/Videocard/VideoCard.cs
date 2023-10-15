using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;

public class VideoCard : IClone<VideoCardBuilder>
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

    public VideoCardBuilder Clone()
    {
        var builder = new VideoCardBuilder();
        builder.WithChipFrequency(_chipFrequency);
        builder.WithPciVersion(_pciVersion);
        builder.WithPowerConsumption(_powerConsumption);
        builder.WithVideoMemoryAmount(_videoMemoryAmount);
        builder.WithVideoCardDimensions(_dimensions);
        return builder;
        }
}