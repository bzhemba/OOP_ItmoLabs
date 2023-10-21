using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;

public class Xmp
{
    private IReadOnlyCollection<int> _timings;

    public Xmp(IReadOnlyCollection<int> timings, Frequency frequency, Voltage voltage)
    {
        _timings = timings;
        Frequency = frequency;
        Voltage = voltage;
    }

    public Voltage Voltage { get; }

    public Frequency Frequency { get; }
    public bool IsCompatible(Cpu cpu)
    {
        if (cpu != null && cpu.MemoryFrequency.Mhz < Frequency.Mhz)
        {
            return false;
        }

        return true;
    }

    public XmpBuilder Direct(XmpBuilder builder)
    {
        if (builder != null)
        {
            builder.WithFrequency(Frequency).WithTimings(_timings).WithVoltage(Voltage).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}