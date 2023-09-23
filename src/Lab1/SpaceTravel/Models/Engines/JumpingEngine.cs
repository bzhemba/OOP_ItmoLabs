namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

public class JumpingEngine : Engine
{
    public JumpingEngine()
        : base()
    {
        FuelType = EngineFuel.GravitonMatter;
        Thrust = 90221;
    }
}