using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;

public class EngineE : Engine
{
    public EngineE(double fuelAmount)
        : base(fuelAmount)
    {
    }

    public override double FuelConsumption
    {
        set
        {
            Math.Pow(Thrust / SpecificImpulse, 2);
        }
    }
}