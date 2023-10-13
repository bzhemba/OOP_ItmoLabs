using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.WiFiAdapterCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;

public interface IWifiAdapterBuilder
{
    IWifiAdapterBuilder WithStandartVersion(StandartVersion standartVersion);
    IWifiAdapterBuilder WithBluetoothModule(bool hasBluetoothModule);
    IWifiAdapterBuilder WithPciVersion(PciVersion pciVersion);
    IWifiAdapterBuilder WithPowerConsumption(PowerConsumption powerConsumption);
    WifiAdapter Build();
}