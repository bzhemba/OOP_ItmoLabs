using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class HddCriteria
{
    public HddCriteria(Speed? spindleSpeed, Capacity? capacity, PowerConsumption? powerConsumption)
    {
        SpindleSpeed = spindleSpeed;
        Capacity = capacity;
        PowerConsumption = powerConsumption;
    }

    public Speed? SpindleSpeed { get; }
    public Capacity? Capacity { get; }
    public PowerConsumption? PowerConsumption { get; }
}