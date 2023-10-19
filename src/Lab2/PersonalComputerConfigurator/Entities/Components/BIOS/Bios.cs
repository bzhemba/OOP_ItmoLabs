using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;

public class Bios : IClone<BiosBuilder>
{
    private BiosType _biosType;
    private BiosVersion _biosVersion;
    private ICollection<Cpu> _supportiveCpus;

    public Bios(BiosType biosType, BiosVersion biosVersion, ICollection<Cpu> supportiveCpus)
    {
        _biosType = biosType;
        _biosVersion = biosVersion;
        _supportiveCpus = supportiveCpus;
    }

    public bool IsCompatible(Cpu cpu)
    {
        return _supportiveCpus.Any(supportiveCpu => cpu == supportiveCpu);
    }

    public BiosBuilder Clone()
    {
        var builder = new BiosBuilder();
        builder.WithType(_biosType);
        builder.WithVersion(_biosVersion);
        builder.WithSupportiveCpus(_supportiveCpus);
        return builder;
    }
}