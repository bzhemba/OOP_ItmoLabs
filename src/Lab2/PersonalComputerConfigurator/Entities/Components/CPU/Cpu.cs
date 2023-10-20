using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public class Cpu
{
    public Cpu(
        Socket socket,
        Amount coresAmount,
        Frequency coresFrequency,
        Tdp tdp,
        Frequency memoryFrequency,
        PowerConsumption powerConsumption)
    {
        Socket = socket;
        CoresAmount = coresAmount;
        CoresFrequency = coresFrequency;
        Tdp = tdp;
        MemoryFrequency = memoryFrequency;
        PowerConsumption = powerConsumption;
    }

    public Amount CoresAmount { get; }
    public Frequency CoresFrequency { get; }
    public PowerConsumption PowerConsumption { get; }

    public Frequency MemoryFrequency { get; }

    public Socket Socket { get; }

    public Tdp Tdp { get; }

    public virtual bool HasVideoCore { get; }
    public object Clone()
    {
        var cpuBuilder = new CpuBuilder();
        cpuBuilder.WithCoresAmount(CoresAmount);
        cpuBuilder.WithSocket(Socket);
        cpuBuilder.WithPowerConsumption(PowerConsumption);
        cpuBuilder.WithMemoryFrequency(MemoryFrequency);
        cpuBuilder.WithCoresFrequency(CoresFrequency);
        cpuBuilder.WithTDP(Tdp);
        return cpuBuilder;
    }

    public CpuBuilder Direct(CpuBuilder builder)
    {
        if (builder != null)
        {
            builder.WithPowerConsumption(PowerConsumption).WithSocket(Socket).WithCoresAmount(CoresAmount)
                .WithCoresFrequency(CoresFrequency).WithMemoryFrequency(MemoryFrequency).WithTDP(Tdp).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}