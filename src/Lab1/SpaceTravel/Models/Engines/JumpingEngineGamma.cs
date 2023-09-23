using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;

public class JumpingEngineGamma : JumpingEngine
{
    public JumpingEngineGamma(int fuelAmount)
        : base(fuelAmount)
    {
    }

    public override double FuelConsumption
    {
        // какая-то проблема в этом месте
        set { Math.Pow(Thrust / SpecificImpulse, 2); }
    }
}