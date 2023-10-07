using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
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
    public TravelResult PassingEnvironment(ISpaceShip spaceShip)
    {
        if (spaceShip == null) throw new NullObjectException($"No Space Ship to pass this environment");
        bool hasImpulseEngine = spaceShip.Engines.Any(engine => engine.TypeOfEngine == TypeOfEngine.Impulse);

        if (!hasImpulseEngine)
        {
            return TravelResult.ShipDestruction;
        }

        if (_meteorites != null)
        {
            foreach (Meteorite meteorite in _meteorites)
            {
                if (!spaceShip.CollisionWithMeteorite(meteorite))
                {
                    return TravelResult.ShipDestruction;
                }
            }
        }

        if (_asteroids == null) return TravelResult.Success;
        foreach (Asteroid asteroid in _asteroids)
        {
            if (!spaceShip.CollisionWithAsteroid(asteroid))
            {
                return TravelResult.ShipDestruction;
            }
        }

        return TravelResult.Success;
    }

    private static void CheckDistance(double distance)
    {
        if (distance <= 0)
        {
            throw new IncorrectFormatException($"Distance must be a positive number");
        }
    }
}