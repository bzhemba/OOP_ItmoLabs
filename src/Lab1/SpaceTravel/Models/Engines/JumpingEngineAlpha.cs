namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

public class JumpingEngineAlpha : Engine
{
    public JumpingEngineAlpha()
        : base()
    {
        FuelType = EngineFuel.GravitonMatter;
        Thrust = 90221;
    }
}