using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.SsdCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;

public class Ssd : IClone<SsdBuilder>
{
    private Connection _connection;
    private Capacity _capacity;
    private Speed _speed;

    public Ssd(Connection connection, Capacity capacity, Speed speed, PowerConsumption powerConsumption)
    {
        _connection = connection;
        _capacity = capacity;
        _speed = speed;
        PowerConsumption = powerConsumption;
    }

    public PowerConsumption PowerConsumption { get; }

    public SsdBuilder Clone()
    {
        var builder = new SsdBuilder();
        builder.WithPowerConsumption(PowerConsumption);
        builder.WithConnection(_connection);
        builder.WithCapacity(_capacity);
        builder.WithMaxSpeed(_speed);
        return builder;
    }
}