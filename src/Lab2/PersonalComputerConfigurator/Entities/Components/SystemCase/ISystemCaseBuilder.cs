using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCase;

public interface ISystemCaseBuilder
{
    ISystemCaseBuilder WithVideoCardDimensions(VideoCardDimensions videoCardDimensions);
    ISystemCaseBuilder WithSupportiveFormFactors(IReadOnlyCollection<FormFactor> supportiveMotherboardFormFactors);
    ISystemCaseBuilder WithDimensions(Dimensions dimensions);
    SystemCase Build();
}