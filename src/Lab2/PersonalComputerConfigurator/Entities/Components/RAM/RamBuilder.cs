using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;

public class RamBuilder
{
    private MemorySize? _memorySize;
    private RamFormFactor _ramFormFactor;
    private Xmp? _profile;
    private DdrVersion? _ddrVersion;
    private PowerConsumption? _powerConsumption;
    private IList<(Frequency Frequency, Voltage Voltage)>? _supportiveFrequencyVoltagePairs;

    public RamBuilder WithMemorySize(MemorySize memorySize)
    {
            _memorySize = memorySize;
            return this;
    }

    public RamBuilder WithFormFactor(RamFormFactor ramFormFactor)
    {
        _ramFormFactor = ramFormFactor;
        return this;
    }

    public RamBuilder WithXmp(Xmp profile)
    {
        _profile = profile;
        return this;
    }

    public RamBuilder WithDdrVersion(DdrVersion ddrVersion)
    {
            _ddrVersion = ddrVersion;
            return this;
    }

    public RamBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
            _powerConsumption = powerConsumption;
            return this;
    }

    public RamBuilder WithSupportiveFrequencyVoltagePairs(IList<(Frequency Frequency, Voltage Voltage)> supportiveFrequencyVoltagePairs)
    {
        _supportiveFrequencyVoltagePairs = supportiveFrequencyVoltagePairs;
        return this;
    }

    public Ram Build()
    {
            return new Ram(
                _memorySize ?? throw new ArgumentNullException(nameof(_memorySize)),
                _ramFormFactor,
                _profile ?? throw new ArgumentNullException(nameof(_profile)),
                _ddrVersion ?? throw new ArgumentNullException(nameof(_ddrVersion)),
                _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
                _supportiveFrequencyVoltagePairs ?? throw new ArgumentNullException(nameof(_supportiveFrequencyVoltagePairs)));
    }
}