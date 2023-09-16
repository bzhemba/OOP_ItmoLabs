using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities;

public class JumpingEngineGamma : JumpingEngine
{
    public JumpingEngineGamma(int fuelAmount)
        : base(fuelAmount)
    {
    }

    protected override double FuelConsumption
    {
        set { Math.Pow(Thrust / SpecificImpulse, 2); }
    }
}