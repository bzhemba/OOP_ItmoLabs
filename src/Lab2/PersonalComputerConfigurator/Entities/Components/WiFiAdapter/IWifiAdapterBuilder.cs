using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;

public interface IWifiAdapterBuilder
{
   (AddNotification? Notification, DisclaimerOfWarrantyObligations? Disclaimer) Build();
}