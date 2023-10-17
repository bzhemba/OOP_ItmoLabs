using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.Notifications;

public record Success(Computer Computer) : AddNotification;