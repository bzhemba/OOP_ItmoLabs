using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.HddCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;

public class Hdd : IHddBuilderDirector
{
    private Capacity _capacity;
    private SpindleSpeed _spindleSpeed;
    private PowerConsumption _powerConsumption;

    public Hdd(Capacity capacity, SpindleSpeed spindleSpeed, PowerConsumption powerConsumption)
    {
        _capacity = capacity;
        _spindleSpeed = spindleSpeed;
        _powerConsumption = powerConsumption;
    }

    public IHddBuilder Direct(IHddBuilder builder)
    {
        if (builder != null)
        {
            builder.WithPowerConsumption(_powerConsumption);
            builder.WithSpindleSpeed(_spindleSpeed);
            builder.WithCapacity(_capacity);
            return builder;
        }
        else
        {
            throw new NullObjectException("Builder is empty");
        }
    }
}