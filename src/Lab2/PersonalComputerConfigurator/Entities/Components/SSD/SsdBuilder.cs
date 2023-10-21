using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.SsdCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;

public class SsdBuilder
{
    private Connection _connection;
    private Capacity? _capacity;
    private Speed? _maxSpeed;
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

    public SsdBuilder WithMaxSpeed(Speed speed)
    {
            _maxSpeed = speed;
            return this;
    }

    public SsdBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
            _powerConsumption = powerConsumption;
            return this;
    }

    public Ssd Build()
    {
        return new Ssd(
            _connection,
            _capacity ?? throw new ArgumentNullException(nameof(_capacity)),
            _maxSpeed ?? throw new ArgumentNullException(nameof(_maxSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}