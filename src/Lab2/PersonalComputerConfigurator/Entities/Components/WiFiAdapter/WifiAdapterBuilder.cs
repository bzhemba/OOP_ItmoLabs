using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.WiFiAdapterCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;

public class WifiAdapterBuilder : IWifiAdapterBuilder
{
    private StandartVersion? _standartVersion;
    private bool _hasBluetoothModule;
    private PciVersion? _pciVersion;
    private PowerConsumption? _powerConsumption;
    public IWifiAdapterBuilder WithStandartVersion(StandartVersion standartVersion)
    {
        _standartVersion = standartVersion;
        return this;
    }

    public IWifiAdapterBuilder WithBluetoothModule(bool hasBluetoothModule)
    {
        _hasBluetoothModule = hasBluetoothModule;
        return this;
    }

    public IWifiAdapterBuilder WithPciVersion(PciVersion pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public IWifiAdapterBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WifiAdapter Build()
    {
        if (_standartVersion != null && _powerConsumption != null && _pciVersion != null)
        {
            return new WifiAdapter(_standartVersion, _hasBluetoothModule, _pciVersion, _powerConsumption);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}