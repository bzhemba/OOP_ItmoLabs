using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class RamCriteria
{
    public RamCriteria(
        MemorySize? memorySize,
        RamFormFactor? formFactor,
        PowerConsumption? powerConsumption,
        DdrVersion? ddrVersion)
    {
        MemorySize = memorySize;
        FormFactor = formFactor;
        PowerConsumption = powerConsumption;
        DdrVersion = ddrVersion;
    }

    public MemorySize? MemorySize { get; }
    public RamFormFactor? FormFactor { get; }

    public PowerConsumption? PowerConsumption { get; }

    public DdrVersion? DdrVersion { get; }
}