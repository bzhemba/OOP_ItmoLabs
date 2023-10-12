using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.SsdCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;

public class Ssd
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
}