using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class SystemUnitCriteria
{
    public SystemUnitCriteria(VideoCardDimensions? cardDimensions, Dimensions? dimensions)
    {
        CardDimensions = cardDimensions;
        Dimensions = dimensions;
    }

    public VideoCardDimensions? CardDimensions { get; }
    public Dimensions? Dimensions { get; }
}