namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;

public class Meteorites : Obstacle
{
    public override int ShipDamage()
    {
        // передавать корабль
        return 0;
    }

    public override int DeflectorDamage()
    {
        // передавать дефлектор
        return 0;
    }
}