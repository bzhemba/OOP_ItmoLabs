using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;

public class HddBuilder
{
    private Capacity? _capacity;
    private Speed? _spindleSpeed;
    private PowerConsumption? _powerConsumption;

    public HddBuilder WithCapacity(Capacity capacity)
    {
            _capacity = capacity;
            return this;
    }

    public HddBuilder WithSpindleSpeed(Speed spindleSpeed)
    {
            _spindleSpeed = spindleSpeed;
            return this;
    }

    public HddBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
            _powerConsumption = powerConsumption;
            return this;
    }

    public Hdd Build()
    {
            return new Hdd(
                _capacity ?? throw new ArgumentNullException(nameof(_capacity)),
                _spindleSpeed ?? throw new ArgumentNullException(nameof(_spindleSpeed)),
                _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}