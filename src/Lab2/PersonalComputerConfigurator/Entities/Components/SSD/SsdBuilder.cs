using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.SsdCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;

public class SsdBuilder
{
    private Connection _connection;
    private Capacity? _capacity;
    private MaxSpeed? _maxSpeed;
    private PowerConsumption? _powerConsumption;
    public SsdBuilder WithConnection(Connection connection)
    {
        _connection = connection;
        return this;
    }

    public SsdBuilder WithCapacity(Capacity capacity)
    {
        _capacity = capacity;
        return this;
    }

    public SsdBuilder WithMaxSpeed(MaxSpeed maxSpeed)
    {
        _maxSpeed = maxSpeed;
        return this;
    }

    public SsdBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ssd Build()
    {
        if (_powerConsumption != null && _maxSpeed != default && _capacity != null && _connection != default)
        {
            return new Ssd(_connection, _capacity, _maxSpeed,  _powerConsumption);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}