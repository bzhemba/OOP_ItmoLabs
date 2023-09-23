using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class PleasureShuttle : ISpaceShip
{
    private HullClass1 _hull = new();
    private EngineC _engine = new();
    public EngineC Engine { get => _engine; }

    public void CollisionWithMeteorite(Meteorite meteorite)
    {
        if (meteorite != null)
        {
            int damage = meteorite.DamagePoints;
            _hull.TakeDamage(damage);
        }
    }

    public void CollisionWithAntimatterFlares()
    {
        throw new SpaceCrewDestroyedException($"Space ship doesn't have a deflector with modification." +
                                              $"The ship's crew has been destroyed");
    }

    public void CollisionWithSpaceWhale()
    {
        throw new SpaceShipDestroyedException($"Space ship has been destroyed");
    }

    public void CollisionWithAsteroid(Asteroid asteroid)
    {
        if (asteroid != null)
        {
            int damage = asteroid.DamagePoints;
            _hull.TakeDamage(damage);
        }
    }
}