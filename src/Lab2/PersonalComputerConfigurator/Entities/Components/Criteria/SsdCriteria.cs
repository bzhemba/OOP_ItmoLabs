using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.SsdCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class SsdCriteria
{
    public SsdCriteria(Connection? connection, Capacity? capacity, Speed? speed, PowerConsumption? powerConsumption)
    {
        Connection = connection;
        Capacity = capacity;
        Speed = speed;
        PowerConsumption = powerConsumption;
    }

    public Connection? Connection { get; }
    public Capacity? Capacity { get; }
    public Speed? Speed { get; }
    public PowerConsumption? PowerConsumption { get; }
}