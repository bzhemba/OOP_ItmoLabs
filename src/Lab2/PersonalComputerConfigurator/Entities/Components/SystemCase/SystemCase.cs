using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCase;

public class SystemCase
{
    private Dimensions _videoCardDimensions;
    private IReadOnlyCollection<FormFactor> _supportiveMotherboardFormFactors;
    private Dimensions _dimensions;

    public SystemCase(Dimensions videoCardDimensions, IReadOnlyCollection<FormFactor> supportiveMotherboardFormFactors, Dimensions dimensions)
    {
        _videoCardDimensions = videoCardDimensions;
        _supportiveMotherboardFormFactors = supportiveMotherboardFormFactors;
        _dimensions = dimensions;
    }
}