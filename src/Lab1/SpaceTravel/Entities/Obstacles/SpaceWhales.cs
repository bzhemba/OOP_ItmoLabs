namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;

public class SpaceWhales : Obstacle
{
    public SpaceWhales()
    {
    }

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