using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class CpuCriteria
{
    public CpuCriteria(Frequency? coresFrequency, PowerConsumption? powerConsumption, Frequency? memoryFrequency, Socket? socket)
    {
        CoresFrequency = coresFrequency;
        PowerConsumption = powerConsumption;
        MemoryFrequency = memoryFrequency;
        Socket = socket;
    }

    public Frequency? CoresFrequency { get; }
    public PowerConsumption? PowerConsumption { get; }

    public Frequency? MemoryFrequency { get; }

    public Socket? Socket { get; }
}