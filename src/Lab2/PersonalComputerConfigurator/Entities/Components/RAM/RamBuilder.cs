using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;

public class RamBuilder : IRamBuilder
{
    private MemorySize? _memorySize;
    private FormFactor _formFactor;
    private Xmp? _profile;
    private DdrVersion? _ddrVersion;
    private PowerConsumption? _powerConsumption;
    private IList<FrequencyVoltagePair>? _supportiveFrequencyVoltagePairs;

    public IRamBuilder WithMemorySize(MemorySize memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public IRamBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRamBuilder WithXmp(Xmp profile)
    {
        _profile = profile;
        return this;
    }

    public IRamBuilder WithDdrVersion(DdrVersion ddrVersion)
    {
        _ddrVersion = ddrVersion;
        return this;
    }

    public IRamBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IRamBuilder WithSupportiveFrequencyVoltagePairs(IList<FrequencyVoltagePair> supportiveFrequencyVoltagePairs)
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