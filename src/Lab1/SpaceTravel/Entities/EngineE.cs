using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities;

public class EngineE : Engine
{
    public EngineE(double fuelAmount)
        : base(fuelAmount)
    {
    }

    protected override double FuelConsumption
    {
        set { Math.Pow(Thrust / SpecificImpulse, 2); }
    }
}