using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class BiosCriteria
{
    public BiosCriteria(BiosType? biosType, BiosVersion? biosVersion)
    {
        BiosType = biosType;
        BiosVersion = biosVersion;
    }

    public BiosType? BiosType { get; }
    public BiosVersion? BiosVersion { get; }
}