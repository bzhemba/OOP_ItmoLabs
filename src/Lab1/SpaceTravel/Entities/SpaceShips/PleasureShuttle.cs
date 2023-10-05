using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class PleasureShuttle : ISpaceShip
{
    private const int Weight = 21;
    private const int StartingFuel = 300;
    private readonly Hull _hull;
    public PleasureShuttle(Hull hull, IReadOnlyCollection<Engine> engines)
    {
        CheckEngines(engines);
        CheckHull(hull);
        _hull = hull;
        Engines = engines;
        StartTheEngines();
    }

    public IReadOnlyCollection<Engine> Engines { get; }
    public string Name { get; } = NameOfSpaceShip.PleasureShuttle.ToString();

    public void AddPhotonDeflector()
    {
        throw new NullObjectException($"Pleasure shuttle doesn't have deflectors. You can't add Photon Modification");
    }

    public void CollisionWithMeteorite(Meteorite? meteorite)
    {
        if (meteorite == null) return;
        int damage = meteorite.DamagePoints;
        _hull.TakeDamage(damage);
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

    public void CollisionWithAsteroid(Asteroid? asteroid)
    {
        if (asteroid == null) return;
        int damage = asteroid.DamagePoints;
        _hull.TakeDamage(damage);
    }

    public double ComputeSpeed()
        {
            const int coefficient = 10;
            int sum = Engines.Sum(engine => (int)engine.Power());

            return sum * coefficient / Weight;
        }

    private void CheckHull(Hull hull)
    {
        bool hullIsValid = hull is HullClassOne;
        if (!hullIsValid)
        {
            throw new IncorrectFormatException($"Not the right type of hull. " +
                                               $"{Name} can have only Hull Class One");
        }
    }

    private void CheckEngines(IReadOnlyCollection<Engine> engines)
    {
        bool allEnginesAreValid = engines.All(engine => engine is EngineClassC);
        if (!allEnginesAreValid)
        {
            throw new IncorrectFormatException($"Not the right type of all engines. " +
                                               $"{Name} can have only Engine Class C");
        }
    }

    private void StartTheEngines()
    {
        foreach (Engine engine in Engines)
        {
            engine.AddFuel(StartingFuel);
            engine.StartingEngine();
        }
    }
}