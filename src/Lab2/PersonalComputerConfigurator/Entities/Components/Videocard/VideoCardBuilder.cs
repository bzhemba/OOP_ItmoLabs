using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;

public class VideoCardBuilder
{
    private VideoCardDimensions? _dimensions;
    private VideoMemoryAmount? _videoMemoryAmount;
    private PciVersion? _pciVersion;
    private ChipFrequency? _chipFrequency;
    private PowerConsumption? _powerConsumption;
    public VideoCardBuilder WithVideoCardDimensions(VideoCardDimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public VideoCardBuilder WithVideoMemoryAmount(VideoMemoryAmount videoMemoryAmount)
    {
        _videoMemoryAmount = videoMemoryAmount;
        return this;
    }

    public VideoCardBuilder WithPciVersion(PciVersion pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public VideoCardBuilder WithChipFrequency(ChipFrequency chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public VideoCardBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public VideoCard Build()
    {
        if (_dimensions != null && _powerConsumption != null && _chipFrequency != null && _pciVersion != null &&
            _videoMemoryAmount != null)
        {
            return new VideoCard(_dimensions, _videoMemoryAmount, _pciVersion, _chipFrequency, _powerConsumption);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}