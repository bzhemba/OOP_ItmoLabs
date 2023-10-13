using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.WiFiAdapterCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;

public class WifiAdapter : IWifiAdapterBuilderDirector
{
    private StandartVersion _standartVersion;
    private bool _hasBluetoothModule;
    private PciVersion _pciVersion;
    private PowerConsumption _powerConsumption;

    public WifiAdapter(StandartVersion standartVersion, bool hasBluetoothModule, PciVersion pciVersion, PowerConsumption powerConsumption)
    {
        _standartVersion = standartVersion;
        _hasBluetoothModule = hasBluetoothModule;
        _pciVersion = pciVersion;
        _powerConsumption = powerConsumption;
    }

    public IWifiAdapterBuilder Direct(IWifiAdapterBuilder builder)
    {
        if (builder != null)
        {
            builder.WithBluetoothModule(_hasBluetoothModule);
            builder.WithPciVersion(_pciVersion);
            builder.WithPowerConsumption(_powerConsumption);
            builder.WithStandartVersion(_standartVersion);
            return builder;
        }
        else
        {
            throw new NullObjectException("Builder is empty");
        }
    }
}