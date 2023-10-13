using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.SsdCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;

public interface ISsdBuilder
{
    ISsdBuilder WithConnection(Connection connection);
    ISsdBuilder WithCapacity(Capacity capacity);
    ISsdBuilder WithMaxSpeed(MaxSpeed maxSpeed);
    ISsdBuilder WithPowerConsumption(PowerConsumption powerConsumption);
    Ssd Build();
}