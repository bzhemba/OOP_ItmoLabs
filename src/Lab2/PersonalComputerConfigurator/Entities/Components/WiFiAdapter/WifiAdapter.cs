using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;

public class WifiAdapter : ICloneable
{
    private VersionNumber _standartVersion;
    private bool _hasBluetoothModule;
    private VersionNumber _versionNumber;

    public WifiAdapter(VersionNumber standartVersion, bool hasBluetoothModule, VersionNumber versionNumber, PowerConsumption powerConsumption)
    {
        _standartVersion = standartVersion;
        _hasBluetoothModule = hasBluetoothModule;
        _versionNumber = versionNumber;
        PowerConsumption = powerConsumption;
    }

    public PowerConsumption PowerConsumption { get; }

    public object Clone()
    {
        var builder = new WifiAdapterBuilder();
        builder.WithBluetoothModule(_hasBluetoothModule);
        builder.WithPciVersion(_versionNumber);
        builder.WithPowerConsumption(PowerConsumption);
        builder.WithStandartVersion(_standartVersion);
        return builder;
    }

    public WifiAdapterBuilder Direct(WifiAdapterBuilder builder)
    {
        if (builder != null)
        {
            builder.WithBluetoothModule(_hasBluetoothModule).WithPciVersion(_versionNumber)
                .WithStandartVersion(_standartVersion).WithPowerConsumption(PowerConsumption).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}
