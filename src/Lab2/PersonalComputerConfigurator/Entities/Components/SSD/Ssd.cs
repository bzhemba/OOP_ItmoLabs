using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.SsdCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;

public class Ssd : ISsdBuilderDirector
{
    private Connection _connection;
    private Capacity _capacity;
    private MaxSpeed _maxSpeed;
    private PowerConsumption _powerConsumption;

    public Ssd(Connection connection, Capacity capacity, MaxSpeed maxSpeed, PowerConsumption powerConsumption)
    {
        _connection = connection;
        _capacity = capacity;
        _maxSpeed = maxSpeed;
        _powerConsumption = powerConsumption;
    }

    public ISsdBuilder Direct(ISsdBuilder builder)
    {
        if (builder != null)
        {
            builder.WithPowerConsumption(_powerConsumption);
            builder.WithConnection(_connection);
            builder.WithCapacity(_capacity);
            builder.WithMaxSpeed(_maxSpeed);
            return builder;
        }
        else
        {
            throw new NullObjectException("Builder is empty");
        }
    }
}