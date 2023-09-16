using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities;

public class JumpingEngineOmega : JumpingEngine
{
    public JumpingEngineOmega(int fuelAmount)
        : base(fuelAmount)
    {
    }

    protected override double FuelConsumption
    {
        set { Math.Log(2, Thrust / SpecificImpulse); }
    }
}