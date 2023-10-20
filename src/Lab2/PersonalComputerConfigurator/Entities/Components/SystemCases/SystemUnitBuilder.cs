using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCases;

public class SystemUnitBuilder
{
    private VideoCardDimensions? _videoCardDimensions;
    private ICollection<FormFactor>? _supportiveMotherboardFormFactors;
    private Dimensions? _dimensions;
    public SystemUnitBuilder WithVideoCardDimensions(VideoCardDimensions videoCardDimensions)
    {
        _videoCardDimensions = videoCardDimensions;
        return this;
    }

    public SystemUnitBuilder WithSupportiveFormFactors(ICollection<FormFactor> supportiveMotherboardFormFactors)
    {
        _supportiveMotherboardFormFactors = supportiveMotherboardFormFactors;
        return this;
    }

    public SystemUnitBuilder WithDimensions(Dimensions dimensions)
    {
            _dimensions = dimensions;
            return this;
    }

    public SystemUnit Build()
    {
        return new SystemUnit(
            _videoCardDimensions ?? throw new ArgumentNullException(nameof(_videoCardDimensions)),
            _supportiveMotherboardFormFactors ?? throw new ArgumentNullException(nameof(_supportiveMotherboardFormFactors)),
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)));
    }
}