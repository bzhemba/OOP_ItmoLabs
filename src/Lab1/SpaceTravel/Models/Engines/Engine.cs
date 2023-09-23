using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EngineExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

public class Engine
{
    private protected const double SpecificImpulse = 3222.6;
    private int _consumedFuelAmount;
    private int _fuelAmount;
    protected EngineFuel FuelType { get; set; } = EngineFuel.Default;
    protected int Thrust { get; set; } = 80000;

    public virtual double FuelConsumption()
    {
        return Thrust / SpecificImpulse;
    }

    public double ConsumedFuel(int time)
    {
        _consumedFuelAmount += (int)FuelConsumption() * time;
        return _consumedFuelAmount;
    }

    public virtual void StartingEngine()
    {
        int startingFuelAmount = 150;
        if (_fuelAmount - startingFuelAmount < 0)
            throw new EngineLackOfFuelException($"Fuel is out");
        _consumedFuelAmount += startingFuelAmount;
        _fuelAmount -= startingFuelAmount;
    }

    public virtual void AddFuel(int extraFuel)
    {
        _fuelAmount += extraFuel;
    }
}