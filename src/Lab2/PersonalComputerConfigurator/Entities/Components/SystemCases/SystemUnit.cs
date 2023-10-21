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
    private ICollection<FormFactor> _supportiveMotherboardFormFactors;

    public SystemUnit(VideoCardDimensions videoCardDimensions, ICollection<FormFactor> supportiveMotherboardFormFactors, Dimensions dimensions)
    {
        CardDimensions = videoCardDimensions;
        _supportiveMotherboardFormFactors = supportiveMotherboardFormFactors;
        Dimensions = dimensions;
    }

    public VideoCardDimensions CardDimensions { get; }
    public Dimensions Dimensions { get; }

    public bool DoesVideoCardFit(VideoCard videocard)
    {
        return videocard != null &&
               (videocard.Dimensions.Length <= CardDimensions.Length) &&
               (videocard.Dimensions.Width <= CardDimensions.Width);
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
        builder.WithDimensions(Dimensions);
        builder.WithVideoCardDimensions(CardDimensions);
        builder.WithSupportiveFormFactors(_supportiveMotherboardFormFactors);
        return builder;
    }

    public SystemUnitBuilder Direct(SystemUnitBuilder builder)
    {
        if (builder != null)
        {
            builder.WithDimensions(Dimensions).WithVideoCardDimensions(CardDimensions)
                .WithSupportiveFormFactors(_supportiveMotherboardFormFactors).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}