using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.Notifications;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;

public interface IWifiAdapterBuilder
{
   (AddNotification? Notification, DisclaimerOfWarrantyObligations? Disclaimer, NonComplianceOfRecommendedPeakLoad? NonComplianceOfRecommendedPeakLoad, Computer.Computer? Computer) Build();
}