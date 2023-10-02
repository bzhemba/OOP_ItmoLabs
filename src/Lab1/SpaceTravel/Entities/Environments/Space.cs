using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EnvironmentExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

public class Space : IEnvironment
{
    private Collection<Meteorite>? _meteorites;
    private Collection<Asteroid>? _asteroids;
    private int _distance;

    public Space(int distance, Collection<Meteorite>? meteorites, Collection<Asteroid>? asteroids)
    {
        _meteorites = meteorites;
        _asteroids = asteroids;
        _distance = distance;
    }

    public int Distance => _distance;
    public bool PassingEnvironment(ISpaceShip spaceShip)
    {
        if (spaceShip != null)
        {
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

            if (_asteroids != null)
            {
                foreach (Asteroid asteroid in _asteroids)
                {
                    if (asteroid is not null)
                        spaceShip.CollisionWithAsteroid(asteroid);
                }
            }

            return true;
        }

        throw new NullObjectException($"No Space Ship to pass this environment");
    }
}