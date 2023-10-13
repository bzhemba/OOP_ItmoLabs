using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.SsdCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;

public class SsdBuilder : ISsdBuilder
{
    private Connection _connection;
    private Capacity? _capacity;
    private MaxSpeed? _maxSpeed;
    private PowerConsumption? _powerConsumption;
    public ISsdBuilder WithConnection(Connection connection)
    {
        _connection = connection;
        return this;
    }

    public ISsdBuilder WithCapacity(Capacity capacity)
    {
        _capacity = capacity;
        return this;
    }

    public ISsdBuilder WithMaxSpeed(MaxSpeed maxSpeed)
    {
        _maxSpeed = maxSpeed;
        return this;
    }

    public ISsdBuilder WithPowerConsumption(PowerConsumption powerConsumption)
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