using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;

public class RamBuilder
{
    private MemorySize? _memorySize;
    private FormFactor _formFactor;
    private Xmp? _profile;
    private DdrVersion? _ddrVersion;
    private PowerConsumption? _powerConsumption;
    private IList<FrequencyVoltagePair>? _supportiveFrequencyVoltagePairs;

    public RamBuilder WithMemorySize(MemorySize memorySize)
    {
        if (memorySize is { Gb: > 0 })
        {
            _memorySize = memorySize;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of memory size");
        }
    }

    public RamBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public RamBuilder WithXmp(Xmp profile)
    {
        _profile = profile;
        return this;
    }

    public RamBuilder WithDdrVersion(DdrVersion ddrVersion)
    {
        if (ddrVersion is { Version: > 0 })
        {
            _ddrVersion = ddrVersion;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of version");
        }
    }

    public RamBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        if (powerConsumption is { Watt: > 0 })
        {
            _powerConsumption = powerConsumption;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of power consumption");
        }
    }

    public RamBuilder WithSupportiveFrequencyVoltagePairs(IList<FrequencyVoltagePair> supportiveFrequencyVoltagePairs)
    {
        _supportiveFrequencyVoltagePairs = supportiveFrequencyVoltagePairs;
        return this;
    }

    public Ram Build()
    {
        if (_memorySize != null && _formFactor != default && _powerConsumption != null && _profile != null
            && _ddrVersion != null && _supportiveFrequencyVoltagePairs != null)
        {
            return new Ram(_memorySize, _formFactor, _profile, _ddrVersion, _powerConsumption, _supportiveFrequencyVoltagePairs);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}