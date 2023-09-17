using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities;

public class JumpingEngineOmega : JumpingEngine
{
    public JumpingEngineOmega(int fuelAmount)
        : base(fuelAmount)
    {
    }

    public override double FuelConsumption
    {
        set { Math.Log(2, Thrust / SpecificImpulse); }
    }
}