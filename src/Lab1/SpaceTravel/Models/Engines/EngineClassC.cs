using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EngineExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

public class EngineClassC : Engine
{
    private const int ImpulseEngineThrust = 80000;
    private int _fuelAmount;
    private int _consumedFuelAmount;
    public bool IsOn { get; private set; }
    public EngineFuel FuelType { get; private set; } = EngineFuel.ActivePlasma;
    public override int JumpRange { get; }
    public override int Thrust { get; } = ImpulseEngineThrust;
    public override TypeOfEngine TypeOfEngine { get; } = TypeOfEngine.Impulse;

    public override void StartingEngine()
    {
        const int startingFuelAmount = 150;
        if (_fuelAmount - startingFuelAmount < 0)
            throw new EngineLackOfFuelException($"Fuel is out");
        IsOn = true;
        _consumedFuelAmount += startingFuelAmount;
        _fuelAmount -= startingFuelAmount;
    }

    public override void AddFuel(int extraFuel)
    {
        if (extraFuel < 0)
        {
            throw new IncorrectFormatException($"Fuel amount can't be a negative number");
        }

        _fuelAmount += extraFuel;
    }
}
