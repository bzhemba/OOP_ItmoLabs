using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;

public class Bios : ICloneable, IBiosDirector
{
    private ICollection<Cpu> _supportiveCpus;

    public Bios(BiosType biosType, BiosVersion biosVersion, ICollection<Cpu> supportiveCpus)
    {
        BiosType = biosType;
        BiosVersion = biosVersion;
        _supportiveCpus = supportiveCpus;
    }

    public BiosType BiosType { get; }
    public BiosVersion BiosVersion { get; }
    public bool IsCompatible(Cpu cpu)
    {
        return _supportiveCpus.Any(supportiveCpu => cpu == supportiveCpu);
    }

    public void AddSupportiveCpu(Cpu cpu)
    {
        _supportiveCpus.Add(cpu);
    }

    public object Clone()
    {
        var builder = new BiosBuilder();
        builder.WithType(BiosType);
        builder.WithVersion(BiosVersion);
        builder.WithSupportiveCpus(_supportiveCpus);
        return builder;
    }

    public BiosBuilder Direct(BiosBuilder builder)
    {
        if (builder != null)
        {
            builder.WithType(BiosType).WithVersion(BiosVersion).WithSupportiveCpus(_supportiveCpus).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}