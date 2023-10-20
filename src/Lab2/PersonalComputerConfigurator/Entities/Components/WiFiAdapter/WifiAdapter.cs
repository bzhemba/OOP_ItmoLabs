using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;

public class WifiAdapter : ICloneable, IWifiAdapter
{
    private VersionNumber _versionNumber;

    public WifiAdapter(VersionNumber standartVersion, VersionNumber versionNumber, PowerConsumption powerConsumption)
    {
        StandartVersion = standartVersion;
        _versionNumber = versionNumber;
        PowerConsumption = powerConsumption;
    }

    public VersionNumber StandartVersion { get; }
    public PowerConsumption PowerConsumption { get; }
    public bool HasBluetoothModule { get; }

    public object Clone()
    {
        var builder = new WifiAdapterBuilder();
        builder.WithPciVersion(_versionNumber);
        builder.WithPowerConsumption(PowerConsumption);
        builder.WithStandartVersion(StandartVersion);
        return builder;
    }

    public WifiAdapterBuilder Direct(WifiAdapterBuilder builder)
    {
        if (builder != null)
        {
            builder
                .WithStandartVersion(StandartVersion).WithPowerConsumption(PowerConsumption).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}
