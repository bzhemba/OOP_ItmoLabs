using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EngineExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

public class JumpingEngineGamma : Engine
{
    private const int JumpingEngineThrust = 90221;
    private int _fuelAmount;
    private int _consumedFuelAmount;

    public override int JumpRange { get; } = 30;
    public override int Thrust { get; } = JumpingEngineThrust;
    public override TypeOfEngine TypeOfEngine { get; } = TypeOfEngine.Jumping;

    public bool IsOn { get; private set; }

    public EngineFuel FuelType { get; private set; } = EngineFuel.GravitonMatter;

    public override double Power()
    {
        return Math.Pow(Thrust / SpecificImpulse, 2);
    }

    public override void StartingEngine()
    {
        const int startingFuelAmount = 300;
        if (_fuelAmount - startingFuelAmount < 0)
            throw new EngineLackOfFuelException($"Fuel is out");
        IsOn = true;
        _consumedFuelAmount += startingFuelAmount;
        _fuelAmount -= startingFuelAmount;
    }

    public override void AddFuel(int extraFuel)
    {
        if (extraFuel < 0)
            throw new IncorrectFormatException($"Fuel amount can't be a negative number");

        _fuelAmount += extraFuel;
    }
}