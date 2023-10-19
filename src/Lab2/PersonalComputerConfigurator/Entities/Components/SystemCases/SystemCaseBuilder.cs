using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCases;

public class SystemCaseBuilder
{
    private VideoCardDimensions? _videoCardDimensions;
    private IReadOnlyCollection<FormFactor>? _supportiveMotherboardFormFactors;
    private Dimensions? _dimensions;
    public SystemCaseBuilder WithVideoCardDimensions(VideoCardDimensions videoCardDimensions)
    {
        _videoCardDimensions = videoCardDimensions;
        return this;
    }

    public SystemCaseBuilder WithSupportiveFormFactors(IReadOnlyCollection<FormFactor> supportiveMotherboardFormFactors)
    {
        _supportiveMotherboardFormFactors = supportiveMotherboardFormFactors;
        return this;
    }

    public SystemCaseBuilder WithDimensions(Dimensions dimensions)
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