using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;

public class Ram : IClone<RamBuilder>
{
    private MemorySize _memorySize;
    private FormFactor _formFactor;
    private Xmp _profile;
    private IList<FrequencyVoltagePair> _supportiveFrequencyVoltagePairs;

    public Ram(
        MemorySize memorySize,
        FormFactor formFactor,
        Xmp profile,
        DdrVersion ddrVersion,
        PowerConsumption powerConsumption,
        IList<FrequencyVoltagePair> supportiveFrequencyVoltagePairs)
    {
        _memorySize = memorySize;
        _formFactor = formFactor;
        _profile = profile;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
        _supportiveFrequencyVoltagePairs = supportiveFrequencyVoltagePairs;
    }

    public PowerConsumption PowerConsumption { get; }

    public DdrVersion DdrVersion { get; }

    public IList<FrequencyVoltagePair> SupportiveFrequencyVoltagePairs =>
        _supportiveFrequencyVoltagePairs;

    public void ApplyXmpModifications(int index)
    {
        _supportiveFrequencyVoltagePairs[index] = new FrequencyVoltagePair(_profile.Frequency.Mhz, _profile.Voltage.V);
    }

    public RamBuilder Clone()
    {
        var builder = new RamBuilder();
        builder.WithPowerConsumption(PowerConsumption);
        builder.WithXmp(_profile);
        builder.WithDdrVersion(DdrVersion);
        builder.WithFormFactor(_formFactor);
        builder.WithMemorySize(_memorySize);
        builder.WithSupportiveFrequencyVoltagePairs(_supportiveFrequencyVoltagePairs);
        return builder;
    }
}