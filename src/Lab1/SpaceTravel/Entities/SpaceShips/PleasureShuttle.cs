using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class PleasureShuttle : ISpaceShip
{
    private readonly HullClass1 _hull = new();
    private readonly Collection<Engine> _engine = new() { new EngineC() };
    private int _weight = 21;
    public PleasureShuttle()
    {
        foreach (Engine engine in _engine)
        {
            engine.AddFuel(300);
            engine.StartingEngine();
        }
    }

    private Collection<Engine> Engine { get => _engine; }

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

    public Collection<Engine> CheckCompatibility()
    {
        return Engine;
    }

    private int ComputeSpeed()
        {
            int sum = 0;
            foreach (Engine engine in _engine)
            {
                sum += (int)engine.Power();
            }

            return sum * 10 / _weight;
        }
}