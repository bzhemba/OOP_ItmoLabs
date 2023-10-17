using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCase;

public class SystemCaseBuilder
{
    private VideoCardDimensions? _videoCardDimensions;
    private IReadOnlyCollection<FormFactor>? _supportiveMotherboardFormFactors;
    private Dimensions? _dimensions;
    public SystemCaseBuilder WithVideoCardDimensions(VideoCardDimensions videoCardDimensions)
    {
        if (videoCardDimensions is not { Length: > 0, Width: > 0 })
            throw new IncorrectFormatException($"Incorrect format of dimensions");
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
        if (dimensions is { Length: > 0 } and { Height: > 0, Width: > 0 })
        {
            _dimensions = dimensions;
            return this;
        }

        throw new IncorrectFormatException($"Incorrect format of dimensions");
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