using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;

public class VideoCard : IClone<VideoCardBuilder>
{
    private VersionNumber _versionNumber;

    public VideoCard(VideoCardDimensions dimensions, MemorySize videoMemoryAmount, VersionNumber versionNumber, Frequency chipFrequency, PowerConsumption powerConsumption)
    {
        Dimensions = dimensions;
        VideoMemoryAmount = videoMemoryAmount;
        _versionNumber = versionNumber;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public MemorySize VideoMemoryAmount { get; }
    public Frequency ChipFrequency { get; }
    public PowerConsumption PowerConsumption { get; }
    public VideoCardDimensions Dimensions { get; }

    public VideoCardBuilder Clone()
    {
        var builder = new VideoCardBuilder();
        builder.WithChipFrequency(ChipFrequency);
        builder.WithPciVersion(_versionNumber);
        builder.WithPowerConsumption(PowerConsumption);
        builder.WithVideoMemoryAmount(VideoMemoryAmount);
        builder.WithVideoCardDimensions(Dimensions);
        return builder;
        }

    public VideoCardBuilder Direct(VideoCardBuilder builder)
    {
        if (builder != null)
        {
            builder.WithChipFrequency(ChipFrequency).WithPciVersion(_versionNumber)
                .WithPowerConsumption(PowerConsumption).WithVideoMemoryAmount(VideoMemoryAmount)
                .WithVideoCardDimensions(Dimensions).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}