using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;

public class VideoCardBuilder
{
    private VideoCardDimensions? _dimensions;
    private MemorySize? _videoMemoryAmount;
    private VersionNumber? _pciVersion;
    private Frequency? _chipFrequency;
    private PowerConsumption? _powerConsumption;
    public VideoCardBuilder WithVideoCardDimensions(VideoCardDimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public VideoCardBuilder WithVideoMemoryAmount(MemorySize videoMemoryAmount)
    {
        _videoMemoryAmount = videoMemoryAmount;
        return this;
    }

    public VideoCardBuilder WithPciVersion(VersionNumber versionNumber)
    {
        _pciVersion = versionNumber;
        return this;
    }

    public VideoCardBuilder WithChipFrequency(Frequency chipFrequency)
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
        return new VideoCard(
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _videoMemoryAmount ?? throw new ArgumentNullException(nameof(_videoMemoryAmount)),
            _pciVersion ?? throw new ArgumentNullException(nameof(_pciVersion)),
            _chipFrequency ?? throw new ArgumentNullException(nameof(_chipFrequency)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}