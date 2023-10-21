using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.Notifications;

public record Success(PersonalComputer PersonalComputer, DisclaimerOfWarrantyObligations? Disclaimer, NonComplianceOfRecommendedPeakLoad? NonComplianceOfRecommendedPeakLoad) : Notification;