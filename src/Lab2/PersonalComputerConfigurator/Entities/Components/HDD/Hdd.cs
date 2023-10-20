using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;

public class Hdd : IClone<HddBuilder>
{
    public Hdd(Capacity capacity, Speed spindleSpeed, PowerConsumption powerPowerConsumption)
    {
        Capacity = capacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerPowerConsumption;
    }

    public Speed SpindleSpeed { get; }
    public Capacity Capacity { get; }
    public PowerConsumption PowerConsumption { get; }

    public HddBuilder Clone()
    {
        var builder = new HddBuilder();
        builder.WithPowerConsumption(PowerConsumption);
        builder.WithSpindleSpeed(SpindleSpeed);
        builder.WithCapacity(Capacity);
        return builder;
    }

    public HddBuilder Direct(HddBuilder builder)
    {
        if (builder != null)
        {
            builder.WithCapacity(Capacity).WithPowerConsumption(PowerConsumption).WithSpindleSpeed(SpindleSpeed)
                .Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}