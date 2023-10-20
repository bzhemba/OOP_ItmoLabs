using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCases;

public class SystemUnit : IClone<SystemUnitBuilder>
{
    private VideoCardDimensions _videoCardDimensions;
    private ICollection<FormFactor> _supportiveMotherboardFormFactors;
    private Dimensions _dimensions;

    public SystemUnit(VideoCardDimensions videoCardDimensions, ICollection<FormFactor> supportiveMotherboardFormFactors, Dimensions dimensions)
    {
        _videoCardDimensions = videoCardDimensions;
        _supportiveMotherboardFormFactors = supportiveMotherboardFormFactors;
        _dimensions = dimensions;
    }

    public bool DoesVideoCardFit(VideoCard videocard)
    {
        return videocard != null &&
               (videocard.Dimensions.Length <= _videoCardDimensions.Length) &&
               (videocard.Dimensions.Width <= _videoCardDimensions.Width);
    }

    public void AddSupportiveMotherBoardFormFactors(FormFactor formFactor)
    {
        _supportiveMotherboardFormFactors.Add(formFactor);
    }

    public bool DoesMotherboardFit(Motherboard motherBoard)
    {
        return _supportiveMotherboardFormFactors.Any(formFactor => motherBoard != null && formFactor == motherBoard.Formfactor);
    }

    public SystemUnitBuilder Clone()
    {
        var builder = new SystemUnitBuilder();
        builder.WithDimensions(_dimensions);
        builder.WithVideoCardDimensions(_videoCardDimensions);
        builder.WithSupportiveFormFactors(_supportiveMotherboardFormFactors);
        return builder;
    }

    public SystemUnitBuilder Direct(SystemUnitBuilder builder)
    {
        if (builder != null)
        {
            builder.WithDimensions(_dimensions).WithVideoCardDimensions(_videoCardDimensions)
                .WithSupportiveFormFactors(_supportiveMotherboardFormFactors).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}