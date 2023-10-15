using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;

public class Bios : ICheckCompatibility, IBiosClone
{
    private Type _type;
    private Version _version;
    private IReadOnlyCollection<Cpu> _supportiveCpus;

    public Bios(Type type, Version version, IReadOnlyCollection<Cpu> supportiveCpus)
    {
        _type = type;
        _version = version;
        _supportiveCpus = supportiveCpus;
    }

    public NotificationSystem IsCompatible(Cpu cpu)
    {
        return _supportiveCpus.Any(supportiveCpu => cpu == supportiveCpu)
            ? NotificationSystem.Ok : NotificationSystem.IncompatibilityProblem;
    }

    public BiosBuilder Clone()
    {
        var builder = new BiosBuilder();
        builder.WithType(_type);
        builder.WithVersion(_version);
        builder.WithSupportiveCpus(_supportiveCpus);
        return builder;
    }
}