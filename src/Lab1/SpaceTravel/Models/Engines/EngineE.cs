using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

public class EngineE : Engine
{
    public override double FuelConsumption()
    {
        return Math.Pow(Thrust / SpecificImpulse, 2);
    }
}