using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;
using Type = Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics.Type;
using Version = Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics.Version;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;

public class BiosBuilder : IBiosBuilder
{
    private Type _type;
    private Version? _version;
    private IReadOnlyCollection<Cpu>? _supportiveCpus;
    public IBiosBuilder WithType(Type type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithVersion(Version version)
    {
        _version = version;
        return this;
    }

    public IBiosBuilder WithSupportiveCpus(IReadOnlyCollection<Cpu> cpus)
    {
        _supportiveCpus = cpus;
        return this;
    }

    public Bios Build()
    {
        if (_type != default && _version != null && _supportiveCpus != null)
        {
            return new Bios(_type, _version, _supportiveCpus);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}