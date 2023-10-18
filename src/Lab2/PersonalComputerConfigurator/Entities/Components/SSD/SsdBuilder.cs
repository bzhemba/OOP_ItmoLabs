using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.SsdCharacteristics;

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
        if (capacity is { Gb: > 0 })
        {
            _capacity = capacity;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of capacity");
        }
    }

    public SsdBuilder WithMaxSpeed(MaxSpeed maxSpeed)
    {
        if (maxSpeed is { Speed: > 0 })
        {
            _maxSpeed = maxSpeed;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of maximum speed");
        }
    }

    public SsdBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        if (powerConsumption is { Watt: > 0 })
        {
            _powerConsumption = powerConsumption;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of power consumption");
        }
    }

    public Ssd Build()
    {
        if (_powerConsumption != null && _maxSpeed != default && _capacity != null)
        {
            return new Ssd(_connection, _capacity, _maxSpeed,  _powerConsumption);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}