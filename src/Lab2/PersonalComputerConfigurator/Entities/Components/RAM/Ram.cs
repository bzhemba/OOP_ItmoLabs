using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;

public class Ram : IClone<RamBuilder>
{
    private MemorySize _memorySize;
    private RamFormFactor _ramFormFactor;
    private Xmp _profile;
    private IList<(Frequency Frequency, Voltage Voltage)> _supportiveFrequencyVoltagePairs;

    public Ram(
        MemorySize memorySize,
        RamFormFactor ramFormFactor,
        Xmp profile,
        DdrVersion ddrVersion,
        PowerConsumption powerConsumption,
        IList<(Frequency Frequency, Voltage Voltage)> supportiveFrequencyVoltagePairs)
    {
        _memorySize = memorySize;
        _ramFormFactor = ramFormFactor;
        _profile = profile;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
        _supportiveFrequencyVoltagePairs = supportiveFrequencyVoltagePairs;
    }

    public PowerConsumption PowerConsumption { get; }

    public DdrVersion DdrVersion { get; }

    public void ApplyXmpModificationsTo(Frequency frequency, Voltage voltage)
    {
        (Frequency Frequency, Voltage Voltage) firstPairWithThisCharacteristics =
            _supportiveFrequencyVoltagePairs.FirstOrDefault(pair =>
                pair.Frequency == frequency && pair.Voltage == voltage);
        int ind = _supportiveFrequencyVoltagePairs.IndexOf(firstPairWithThisCharacteristics);
        _supportiveFrequencyVoltagePairs[ind] = (new Frequency(_profile.Frequency.Mhz), new Voltage(_profile.Voltage.V));
    }

    public RamBuilder Clone()
    {
        var builder = new RamBuilder();
        builder.WithPowerConsumption(PowerConsumption);
        builder.WithXmp(_profile);
        builder.WithDdrVersion(DdrVersion);
        builder.WithFormFactor(_ramFormFactor);
        builder.WithMemorySize(_memorySize);
        builder.WithSupportiveFrequencyVoltagePairs(_supportiveFrequencyVoltagePairs);
        return builder;
    }

    public RamBuilder Direct(RamBuilder builder)
    {
        if (builder != null)
        {
            builder.WithDdrVersion(DdrVersion).WithXmp(_profile).WithPowerConsumption(PowerConsumption)
                .WithFormFactor(_ramFormFactor).WithMemorySize(_memorySize)
                .WithSupportiveFrequencyVoltagePairs(_supportiveFrequencyVoltagePairs).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}