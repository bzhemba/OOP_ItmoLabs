using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.HddCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;

public class Hdd : IClone<HddBuilder>
{
    private Capacity _capacity;
    private SpindleSpeed _spindleSpeed;
    private PowerConsumption _powerConsumption;

    public Hdd(Capacity capacity, SpindleSpeed spindleSpeed, PowerConsumption powerConsumption)
    {
        _capacity = capacity;
        _spindleSpeed = spindleSpeed;
        _powerConsumption = powerConsumption;
    }

    public HddBuilder Clone()
    {
        var builder = new HddBuilder();
        builder.WithPowerConsumption(_powerConsumption);
        builder.WithSpindleSpeed(_spindleSpeed);
        builder.WithCapacity(_capacity);
        return builder;
    }
}