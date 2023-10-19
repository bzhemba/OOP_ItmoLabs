using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;

public class VideoCard : IClone<VideoCardBuilder>
{
    private MemorySize _videoMemoryAmount;
    private VersionNumber _versionNumber;
    private Frequency _chipFrequency;

    public VideoCard(VideoCardDimensions dimensions, MemorySize videoMemoryAmount, VersionNumber versionNumber, Frequency chipFrequency, PowerConsumption powerConsumption)
    {
        Dimensions = dimensions;
        _videoMemoryAmount = videoMemoryAmount;
        _versionNumber = versionNumber;
        _chipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public PowerConsumption PowerConsumption { get; }
    public VideoCardDimensions Dimensions { get; }

    public VideoCardBuilder Clone()
    {
        var builder = new VideoCardBuilder();
        builder.WithChipFrequency(_chipFrequency);
        builder.WithPciVersion(_versionNumber);
        builder.WithPowerConsumption(PowerConsumption);
        builder.WithVideoMemoryAmount(_videoMemoryAmount);
        builder.WithVideoCardDimensions(Dimensions);
        return builder;
        }
}