using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCase;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;

public interface IHddBuilder
{
    ISystemCaseBuilder WithSystemCase(SystemCase.SystemCase systemCase);
}