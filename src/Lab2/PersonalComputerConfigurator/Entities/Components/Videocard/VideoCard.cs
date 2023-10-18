using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;

public class VideoCard : IClone<VideoCardBuilder>
{
    private VideoMemoryAmount _videoMemoryAmount;
    private PciVersion _pciVersion;
    private ChipFrequency _chipFrequency;

    public VideoCard(VideoCardDimensions dimensions, VideoMemoryAmount videoMemoryAmount, PciVersion pciVersion, ChipFrequency chipFrequency, PowerConsumption powerConsumption)
    {
        Dimensions = dimensions;
        _videoMemoryAmount = videoMemoryAmount;
        _pciVersion = pciVersion;
        _chipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public PowerConsumption PowerConsumption { get; }
    public VideoCardDimensions Dimensions { get; }

    public VideoCardBuilder Clone()
    {
        var builder = new VideoCardBuilder();
        builder.WithChipFrequency(_chipFrequency);
        builder.WithPciVersion(_pciVersion);
        builder.WithPowerConsumption(PowerConsumption);
        builder.WithVideoMemoryAmount(_videoMemoryAmount);
        builder.WithVideoCardDimensions(Dimensions);
        return builder;
        }
}