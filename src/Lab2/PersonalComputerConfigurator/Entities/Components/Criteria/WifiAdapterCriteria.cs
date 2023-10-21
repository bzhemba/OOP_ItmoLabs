using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class WifiAdapterCriteria
{
    public WifiAdapterCriteria(VersionNumber? standartVersion, PowerConsumption? powerConsumption)
    {
        StandartVersion = standartVersion;
        PowerConsumption = powerConsumption;
    }

    public VersionNumber? StandartVersion { get; }
    public PowerConsumption? PowerConsumption { get; }
}