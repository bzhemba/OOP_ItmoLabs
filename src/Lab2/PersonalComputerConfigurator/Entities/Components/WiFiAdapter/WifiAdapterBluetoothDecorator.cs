namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;

public class WifiAdapterBluetoothDecorator : IWifiAdapter
{
    private WifiAdapter _wifiAdapter;

    public WifiAdapterBluetoothDecorator(WifiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
    }

    public bool HasBluetoothModule => true;
}