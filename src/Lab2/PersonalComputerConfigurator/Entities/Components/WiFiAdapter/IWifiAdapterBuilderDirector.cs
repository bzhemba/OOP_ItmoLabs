namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;

public interface IWifiAdapterBuilderDirector
{
    IWifiAdapterBuilder Direct(IWifiAdapterBuilder builder);
}