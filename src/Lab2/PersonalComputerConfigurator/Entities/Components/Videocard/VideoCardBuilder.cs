using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

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
        if (dimensions is not { Length: > 0, Width: > 0 })
            throw new IncorrectFormatException($"Incorrect format of PCI version");
        _dimensions = dimensions;
        return this;
    }

    public VideoCardBuilder WithVideoMemoryAmount(VideoMemoryAmount videoMemoryAmount)
    {
        if (videoMemoryAmount is not { Gb: > 0 })
            throw new IncorrectFormatException($"Incorrect format of PCI version");
        _videoMemoryAmount = videoMemoryAmount;
        return this;
    }

    public VideoCardBuilder WithPciVersion(PciVersion pciVersion)
    {
        if (pciVersion is not { Version: > 0 }) throw new IncorrectFormatException($"Incorrect format of PCI version");
        _pciVersion = pciVersion;
        return this;
    }

    public VideoCardBuilder WithChipFrequency(ChipFrequency chipFrequency)
    {
        if (chipFrequency is not { Frequency: > 0 })
            throw new IncorrectFormatException($"Incorrect format of chip frequency");
        _chipFrequency = chipFrequency;
        return this;
    }

    public VideoCardBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        if (powerConsumption is not { Watt: > 0 })
            throw new IncorrectFormatException($"Incorrect format of power consumption");
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

        throw new NullObjectException("Unable to create component, some parts are missing");
    }
}