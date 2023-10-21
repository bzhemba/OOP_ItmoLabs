using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;

public interface IPowerUnitBuilder
{
    IWifiAdapterBuilder WithWifiAdapter(WifiAdapter? wifiAdapter);
}