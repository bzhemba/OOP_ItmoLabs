namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;

public class Obstacle
{
    public virtual int ShipDamage()
    {
        // передавать корабль
        return 0;
    }

    public virtual int DeflectorDamage()
    {
        // передавать дефлектор
        return 0;
    }
}