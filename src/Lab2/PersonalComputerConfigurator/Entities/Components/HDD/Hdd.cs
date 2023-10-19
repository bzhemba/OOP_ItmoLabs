using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;

public class Hdd : IClone<HddBuilder>
{
    private Capacity _capacity;
    private Speed _spindleSpeed;

    public Hdd(Capacity capacity, Speed spindleSpeed, PowerConsumption powerPowerConsumption)
    {
        _capacity = capacity;
        _spindleSpeed = spindleSpeed;
        PowerConsumption = powerPowerConsumption;
    }

    public PowerConsumption PowerConsumption { get; }

    public HddBuilder Clone()
    {
        var builder = new HddBuilder();
        builder.WithPowerConsumption(PowerConsumption);
        builder.WithSpindleSpeed(_spindleSpeed);
        builder.WithCapacity(_capacity);
        return builder;
    }
}