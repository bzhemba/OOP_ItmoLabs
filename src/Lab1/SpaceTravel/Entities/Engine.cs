using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EngineExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities;

public class Engine
{
    private protected const double SpecificImpulse = 3222.6;
    private double _fuelConsumption;
    public Engine(double fuelAmount)
    {
        FuelAmount = fuelAmount;
        FuelType = EngineFuel.Default;
        Thrust = 80000;
    }

    public double FuelAmount { get; private set; }
    protected virtual double FuelConsumption
    {
        get
        {
            return _fuelConsumption;
        }

        set
        {
            _fuelConsumption = Thrust / SpecificImpulse;
        }
    }

    protected EngineFuel FuelType { get; set; }
    protected int Thrust { get;  set; }
    public double ConsumeFuel(int time)
    {
        if (FuelAmount <= 0)
        {
            throw new EngineLackOfFuelException($"Fuel is out");
        }

        double fuelConsumed = FuelConsumption * time;
        FuelAmount -= fuelConsumed;
        return fuelConsumed;
    }

    public virtual void StartingEngine()
    {
        double startingFuelAmount = 150;
        if (FuelAmount - startingFuelAmount < 0)
            throw new EngineLackOfFuelException($"Fuel is out");
        FuelAmount -= startingFuelAmount;
    }

    public virtual void AddFuel(double extraFuel)
    {
        FuelAmount += extraFuel;
    }
}