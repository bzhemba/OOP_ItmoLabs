using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

public class JumpingEngineOmega : Engine
{
    public JumpingEngineOmega()
        : base()
    {
        FuelType = EngineFuel.GravitonMatter;
        Thrust = 90221;
    }

    public override double FuelConsumption()
    {
        return Math.Log(2, Thrust / SpecificImpulse);
    }
}