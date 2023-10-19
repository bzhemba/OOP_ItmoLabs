using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;

public class WifiAdapterBuilder
{
    private VersionNumber? _standartVersion;
    private bool _hasBluetoothModule;
    private VersionNumber? _pciVersion;
    private PowerConsumption? _powerConsumption;
    public WifiAdapterBuilder WithStandartVersion(VersionNumber standartVersion)
    {
        _standartVersion = standartVersion;
        return this;
    }

    public WifiAdapterBuilder WithBluetoothModule(bool hasBluetoothModule)
    {
        _hasBluetoothModule = hasBluetoothModule;
        return this;
    }

    public WifiAdapterBuilder WithPciVersion(VersionNumber versionNumber)
    {
        _pciVersion = versionNumber;
        return this;
    }

    public WifiAdapterBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WifiAdapter Build()
    {
        return new WifiAdapter(
            _standartVersion ?? throw new ArgumentNullException(nameof(_standartVersion)),
            _hasBluetoothModule,
            _pciVersion ?? throw new ArgumentNullException(nameof(_pciVersion)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}