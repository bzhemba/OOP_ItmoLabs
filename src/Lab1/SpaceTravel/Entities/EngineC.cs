using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities;

public class EngineC : Engine
{
    public EngineC(double fuelAmount)
        : base(fuelAmount)
    {
        FuelType = EngineFuel.ActivePlasma;
    }
}
