using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;
using Dimensions = Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;

public class VideoCard
{
    private Dimensions _dimensions;
    private VideoMemoryAmount _videoMemoryAmount;
    private PciVersion _pciVersion;
    private ChipFrequency _chipFrequency;
    private PowerConsumption _powerConsumption;

    public VideoCard(Dimensions dimensions, VideoMemoryAmount videoMemoryAmount, PciVersion pciVersion, ChipFrequency chipFrequency, PowerConsumption powerConsumption)
    {
        _dimensions = dimensions;
        _videoMemoryAmount = videoMemoryAmount;
        _pciVersion = pciVersion;
        _chipFrequency = chipFrequency;
        _powerConsumption = powerConsumption;
    }
}