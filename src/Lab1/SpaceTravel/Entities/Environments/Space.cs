using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EnvironmentExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

public class Space : IEnvironment
{
    private readonly Collection<Meteorite>? _meteorites;
    private readonly Collection<Asteroid>? _asteroids;

    public Space(double distance, Collection<Meteorite>? meteorites, Collection<Asteroid>? asteroids)
    {
        CheckDistance(distance);
        _meteorites = meteorites;
        _asteroids = asteroids;
        Distance = distance;
    }

    public double Distance { get; }
    public bool PassingEnvironment(ISpaceShip spaceShip)
    {
        if (spaceShip == null) throw new NullObjectException($"No Space Ship to pass this environment");
        bool hasImpulseEngine = spaceShip.Engines.Any(engine => engine.TypeOfEngine == TypeOfEngine.Impulse);

        if (!hasImpulseEngine)
        {
            throw new EnvironmentMismatchException($"This spaceship is not suitable for this environment");
        }

        if (_meteorites != null)
        {
            foreach (Meteorite meteorite in _meteorites)
            {
                if (meteorite is not null)
                    spaceShip.CollisionWithMeteorite(meteorite);
            }
        }

        if (_asteroids == null) return true;
        foreach (Asteroid asteroid in _asteroids)
        {
            if (asteroid is not null)
                spaceShip.CollisionWithAsteroid(asteroid);
        }

        return true;
    }

    private static void CheckDistance(double distance)
    {
        if (distance <= 0)
        {
            throw new IncorrectFormatException($"Distance must be a positive number");
        }
    }
}