using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class VideocardCriteria
{
    public VideocardCriteria(MemorySize? videoMemoryAmount, PowerConsumption? powerConsumption, VideoCardDimensions? dimensions)
    {
        VideoMemoryAmount = videoMemoryAmount;
        PowerConsumption = powerConsumption;
        Dimensions = dimensions;
    }

    public MemorySize? VideoMemoryAmount { get; }
    public PowerConsumption? PowerConsumption { get; }
    public VideoCardDimensions? Dimensions { get; }
}