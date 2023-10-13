using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCase;

public class SystemCaseBuilder : ISystemCaseBuilder
{
    private VideoCardDimensions? _videoCardDimensions;
    private IReadOnlyCollection<FormFactor>? _supportiveMotherboardFormFactors;
    private Dimensions? _dimensions;
    public ISystemCaseBuilder WithVideoCardDimensions(VideoCardDimensions videoCardDimensions)
    {
        _videoCardDimensions = videoCardDimensions;
        return this;
    }

    public ISystemCaseBuilder WithSupportiveFormFactors(IReadOnlyCollection<FormFactor> supportiveMotherboardFormFactors)
    {
        _supportiveMotherboardFormFactors = supportiveMotherboardFormFactors;
        return this;
    }

    public ISystemCaseBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public SystemCase Build()
    {
        if (_dimensions != null && _videoCardDimensions != null && _supportiveMotherboardFormFactors != null)
        {
            return new SystemCase(_videoCardDimensions, _supportiveMotherboardFormFactors, _dimensions);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}