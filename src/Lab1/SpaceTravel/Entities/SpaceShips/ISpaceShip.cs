using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public interface ISpaceShip
{
    public void AddDeflector(int count)
    {
    }

    public void CollisionWithMeteorite(Meteorite meteorite)
    {
    }

    public void CollisionWithAntimatterFlares()
    {
    }

    public void CollisionWithSpaceWhale()
    {
    }

    public void CollisionWithAsteroid(Asteroid asteroid);
}