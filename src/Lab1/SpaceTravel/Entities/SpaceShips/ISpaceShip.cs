using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

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
    public Collection<Engine> CheckCompatibility();
}