using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.HddCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;

public class HddBuilder : IHddBuilder
{
    private Capacity? _capacity;
    private SpindleSpeed? _spindleSpeed;
    private PowerConsumption? _powerConsumption;

    public IHddBuilder WithCapacity(Capacity capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IHddBuilder WithSpindleSpeed(SpindleSpeed spindleSpeed)
    {
        _spindleSpeed = spindleSpeed;
        return this;
    }

    public IHddBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
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