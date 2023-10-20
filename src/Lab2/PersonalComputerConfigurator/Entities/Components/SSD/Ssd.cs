using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.SsdCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;

public class Ssd : IClone<SsdBuilder>
{
    public Ssd(Connection connection, Capacity capacity, Speed speed, PowerConsumption powerConsumption)
    {
        Connection = connection;
        Capacity = capacity;
        Speed = speed;
        PowerConsumption = powerConsumption;
    }

    public Connection Connection { get; }
    public Capacity Capacity { get; }
    public Speed Speed { get; }
    public PowerConsumption PowerConsumption { get; }

    public SsdBuilder Clone()
    {
        var builder = new SsdBuilder();
        builder.WithPowerConsumption(PowerConsumption);
        builder.WithConnection(Connection);
        builder.WithCapacity(Capacity);
        builder.WithMaxSpeed(Speed);
        return builder;
    }

    public SsdBuilder Direct(SsdBuilder builder)
    {
        if (builder != null)
        {
            builder.WithConnection(Connection).WithCapacity(Capacity).WithPowerConsumption(PowerConsumption)
                .WithMaxSpeed(Speed).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}