using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EngineExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

public class JumpingEngineAlpha : Engine
{
    private int _fuelAmount;
    private int _consumedFuelAmount;

    public override int JumpRange { get; } = 20;
    public override int Thrust { get; } = 90221;
    public override TypeOfEngine TypeOfEngine { get; } = TypeOfEngine.Jumping;

    public bool IsOn { get; private set; }

    public EngineFuel FuelType { get; private set; } = EngineFuel.GravitonMatter;
    public override void StartingEngine()
    {
        int startingFuelAmount = 300;
        if (_fuelAmount - startingFuelAmount < 0)
            throw new EngineLackOfFuelException($"Fuel is out");
        IsOn = true;
        _consumedFuelAmount += startingFuelAmount;
        _fuelAmount -= startingFuelAmount;
    }

    public override void AddFuel(int extraFuel)
    {
        _fuelAmount += extraFuel;
    }
}