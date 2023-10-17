using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.HddCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;

public class HddBuilder
{
    private Capacity? _capacity;
    private SpindleSpeed? _spindleSpeed;
    private PowerConsumption? _powerConsumption;

    public HddBuilder WithCapacity(Capacity capacity)
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

    public HddBuilder WithSpindleSpeed(SpindleSpeed spindleSpeed)
    {
        if (spindleSpeed is { Speed: > 0 })
        {
            _spindleSpeed = spindleSpeed;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of spindle speed");
        }
    }

    public HddBuilder WithPowerConsumption(PowerConsumption powerConsumption)
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

    public Hdd Build()
    {
        if (_capacity != null
            && _spindleSpeed != null && _powerConsumption != null)
        {
            return new Hdd(_capacity, _spindleSpeed, _powerConsumption);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}