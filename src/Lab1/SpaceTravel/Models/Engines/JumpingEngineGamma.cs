using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

public class JumpingEngineGamma : Engine
{
    public JumpingEngineGamma()
        : base()
    {
        FuelType = EngineFuel.GravitonMatter;
        Thrust = 90221;
    }

    public override double FuelConsumption()
    {
        return Math.Pow(Thrust / SpecificImpulse, 2);
    }
}