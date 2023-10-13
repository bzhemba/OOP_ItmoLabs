using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCase;

public class SystemCase : ISystemCaseBuilderDirector
{
    private VideoCardDimensions _videoCardDimensions;
    private IReadOnlyCollection<FormFactor> _supportiveMotherboardFormFactors;
    private Dimensions _dimensions;

    public SystemCase(VideoCardDimensions videoCardDimensions, IReadOnlyCollection<FormFactor> supportiveMotherboardFormFactors, Dimensions dimensions)
    {
        _videoCardDimensions = videoCardDimensions;
        _supportiveMotherboardFormFactors = supportiveMotherboardFormFactors;
        _dimensions = dimensions;
    }

    public ISystemCaseBuilder Direct(ISystemCaseBuilder builder)
    {
        if (builder != null)
        {
            builder.WithDimensions(_dimensions);
            builder.WithVideoCardDimensions(_videoCardDimensions);
            builder.WithSupportiveFormFactors(_supportiveMotherboardFormFactors);
            return builder;
        }
        else
        {
            throw new NullObjectException("Builder is empty");
        }
    }
}