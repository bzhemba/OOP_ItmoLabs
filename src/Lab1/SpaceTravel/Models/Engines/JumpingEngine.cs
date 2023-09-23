using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;

public class JumpingEngine : Engine
{
    public JumpingEngine(double fuelAmount)
        : base(fuelAmount)
    {
        FuelType = EngineFuel.GravitonMatter;
        Thrust = 90221;
    }
}