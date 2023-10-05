using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;

public class Vaklas : ISpaceShip
{
    private const int Weight = 40;
    private const int StartingFuel = 300;
    private readonly IReadOnlyCollection<Deflector> _deflectors;
    private readonly Hull _hull;
    public Vaklas(IReadOnlyCollection<Deflector> deflectors, Hull hull, IReadOnlyCollection<Engine> engines)
    {
        CheckDeflectors(deflectors);
        CheckEngines(engines);
        CheckHull(hull);
        _deflectors = deflectors;
        _hull = hull;
        Engines = engines;
        StartTheEngines();
    }

    public IReadOnlyCollection<Engine> Engines { get;  }
    public string Name { get; } = NameOfSpaceShip.Vaklas.ToString();

    public void AddPhotonDeflector()
    {
        Deflector firstTurnedOnDeflector =
            _deflectors.First(deflector => deflector is { IsOn: true, HasPhotonModification: false });
        firstTurnedOnDeflector.AddPhotonModification();
    }

    public void CollisionWithMeteorite(Meteorite? meteorite)
    {
        if (meteorite == null) return;
        int damage = meteorite.DamagePoints;
        foreach (DeflectorClassOne deflector in _deflectors.Where(d => d.IsOn).Cast<DeflectorClassOne>())
        {
            int remainedDamage = deflector.TakeDamage(damage);
            if (remainedDamage != 0)
            {
                damage = remainedDamage;
            }
            else
            {
                damage = 0;
                break;
            }
        }

        if (damage != 0)
        {
            _hull.TakeDamage(damage);
        }
    }

    public void CollisionWithAntimatterFlares()
    {
        if (_deflectors.Cast<DeflectorClassOne>().Where(deflector =>
                deflector.IsOn && deflector.HasPhotonModification).Any(deflector => deflector.ReflectAntimatterFlare()))
        {
            return;
        }

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
        foreach (DeflectorClassOne deflector in _deflectors.Where(d => d.IsOn).Cast<DeflectorClassOne>())
        {
            int remainedDamage = deflector.TakeDamage(damage);
            if (remainedDamage != 0)
            {
                damage = remainedDamage;
            }
            else
            {
                damage = 0;
                break;
            }
        }

        if (damage != 0)
        {
            _hull.TakeDamage(damage);
        }
    }

    public double ComputeSpeed()
    {
        const int coefficient = 10;
        int sum = Engines.Sum(engine => (int)engine.Power());

        return sum * coefficient / Weight;
    }

    private void CheckHull(Hull hull)
    {
        bool hullIsValid = hull is HullClassTwo;
        if (!hullIsValid)
        {
            throw new IncorrectFormatException($"Not the right type of hull. " +
                                               $"{Name} can have only Hull Class Two");
        }
    }

    private void CheckEngines(IReadOnlyCollection<Engine> engines)
    {
        bool allEnginesAreValid = engines.All(engine => engine is EngineClassE or JumpingEngineGamma);
        if (!allEnginesAreValid)
        {
            throw new IncorrectFormatException($"Not the right type of all engines. " +
                                               $"{Name} can have only Engine Class E or Jumping Engine Gamma");
        }
    }

    private void CheckDeflectors(IReadOnlyCollection<Deflector> deflectors)
    {
        bool allDeflectorsAreValid = deflectors.All(deflector => deflector is DeflectorClassOne);
        if (!allDeflectorsAreValid)
        {
            throw new IncorrectFormatException($"Not the right type of all deflectors. " +
                                               $"{Name} can have only Deflector Class One");
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