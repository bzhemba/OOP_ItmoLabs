using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EnvironmentExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;

public class Space : IEnvironment
{
    private Meteorite? _meteorite;
    private Asteroid? _asteroid;
    private int _distance;

    public Space(int distance, Meteorite? meteorite, Asteroid? asteroid)
    {
        _meteorite = meteorite;
        _asteroid = asteroid;
        _distance = distance;
    }

    public int Distance => _distance;
    public bool PassingEnvironment(ISpaceShip spaceShip)
    {
        if (spaceShip != null)
        {
            Collection<Engine> checkEngines = spaceShip.CheckCompatibility();
            int f = 0;
            foreach (Engine engine in checkEngines)
            {
                if (engine.GetType().IsAssignableFrom(typeof(EngineC)) ||
                      engine.GetType().IsAssignableFrom(typeof(EngineE)))
                {
                    f = 1;
                    break;
                }
            }

            if (f == 0)
            {
                throw new EnvironmentMismatchException($"This spaceship is not suitable for this environment");
            }

            if (_meteorite is not null)
            {
                spaceShip.CollisionWithMeteorite(_meteorite);
            }

            if (_asteroid is not null)
            {
                spaceShip.CollisionWithAsteroid(_asteroid);
            }

            return true;
        }

        throw new NullObjectException($"No Space Ship to pass this environment");
    }
}