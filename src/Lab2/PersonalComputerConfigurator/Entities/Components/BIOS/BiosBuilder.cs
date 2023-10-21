using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;

public class BiosBuilder
{
    private BiosType _biosType;
    private BiosVersion? _version;
    private ICollection<Cpu>? _supportiveCpus;
    public BiosBuilder WithType(BiosType biosType)
    {
        _biosType = biosType;
        return this;
    }

    public BiosBuilder WithVersion(BiosVersion biosVersion)
    {
        _version = biosVersion;
        return this;
    }

    public BiosBuilder WithSupportiveCpus(ICollection<Cpu> cpus)
    {
        _supportiveCpus = cpus;
        return this;
    }

    public Bios Build()
    {
        return new Bios(
            _biosType,
            _version ?? throw new ArgumentNullException(nameof(_version)),
            _supportiveCpus ?? throw new ArgumentNullException(nameof(_supportiveCpus)));
    }
}