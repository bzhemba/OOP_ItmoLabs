using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.HddCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;

public interface IHddBuilder
{
    IHddBuilder WithCapacity(Capacity capacity);
    IHddBuilder WithSpindleSpeed(SpindleSpeed spindleSpeed);
    IHddBuilder WithPowerConsumption(PowerConsumption powerConsumption);
    Hdd Build();
}